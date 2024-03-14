using System.Collections.Generic;
using GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Mappers.States.Runtime;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime
{
    public class RemoteStateMachine : RagonProperty, IStateMachineSync, IRemoteStateMachine
    {
        protected RemoteStateMachine(
            IEnemyStateMapper mapper,
            IEntityProvider entityProvider,
            RemoteStateMachineLogger logger) : base(0, false)
        {
            _mapper = mapper;
            _entityProvider = entityProvider;
            _logger = logger;
            _states = new Dictionary<EnemyStateDefinition, IEnemyRemoteState>();
            _flushes = new Dictionary<EnemyStateDefinition, IRemoteStatePayloadFlush>();
            _stateCompressor = new IntCompressor(0, 256);
        }

        private readonly IntCompressor _stateCompressor;

        private readonly IEnemyStateMapper _mapper;
        private readonly IEntityProvider _entityProvider;

        private readonly RemoteStateMachineLogger _logger;
        private readonly Dictionary<EnemyStateDefinition, IEnemyRemoteState> _states;
        private readonly Dictionary<EnemyStateDefinition, IRemoteStatePayloadFlush> _flushes;

        private IEnemyRemoteState _current;

        private int _state;
        private bool _hasPayload;
        private IRemoteStatePayload _payload;

        public void SetState(EnemyStateDefinition definition)
        {
            _state = _mapper.GetId(definition);
            _hasPayload = false;
            _payload = null;

            MarkAsChanged();
        }

        public void SetState(EnemyStateDefinition definition, IRemoteStatePayload payload)
        {
            _state = _mapper.GetId(definition);
            _hasPayload = true;
            _payload = payload;

            MarkAsChanged();
        }

        public void RegisterState(ILifetime lifetime, EnemyStateDefinition definition, IEnemyRemoteState state)
        {
            _states.Add(definition, state);
            _logger.OnStateRegistered(_mapper.GetId(definition), definition.name);
            
            lifetime.ListenTerminate(() =>
            {
                _states.Remove(definition);
                _logger.OnStateUnregistered(_mapper.GetId(definition), definition.name);
            });
        }

        public void RegisterFlush(ILifetime lifetime, EnemyStateDefinition definition, IRemoteStatePayloadFlush flush)
        {
            _flushes.Add(definition, flush);

            lifetime.ListenTerminate(() =>
            {
                _flushes.Remove(definition);
            });
        }

        public override void Serialize(RagonBuffer buffer)
        {
            _logger.OnSerialize(_state, _mapper.GetDefinition(_state).name);

            var compressed = _stateCompressor.Compress(_state);

            buffer.Write(compressed, _stateCompressor.RequiredBits);

            if (_hasPayload == true)
            {
                buffer.WriteBool(true);
                _payload.Serialize(buffer);
            }
            else
            {
                buffer.WriteBool(false);
            }
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_stateCompressor.RequiredBits);
            var hasPayload = buffer.ReadBool();

            _state = _stateCompressor.Decompress(compressed);
            var definition = _mapper.GetDefinition(_state);

            if (_entityProvider.IsMine == true)
            {
                if (hasPayload == true)
                    _flushes[definition].FlushPayload(buffer);

                return;
            }

            _logger.OnDeserialize(_state, definition.name);

            _current?.Break();
            _current = _states[definition];

            _current?.Enter(buffer);
        }
    }
}