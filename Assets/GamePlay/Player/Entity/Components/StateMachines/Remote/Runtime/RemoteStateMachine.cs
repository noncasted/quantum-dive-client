using System.Collections.Generic;
using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Mappers.States.Runtime;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime
{
    public class RemoteStateMachine : RagonProperty, IStateMachineSync, IRemoteStateMachine
    {
        protected RemoteStateMachine(
            IPlayerStateMapper mapper,
            IEntityProvider entityProvider,
            RemoteStateMachineLogger logger) : base(0, false)
        {
            _mapper = mapper;
            _entityProvider = entityProvider;
            _logger = logger;
            _states = new Dictionary<PlayerStateDefinition, IPlayerRemoteState>();
            _flushes = new Dictionary<PlayerStateDefinition, IRemotePayloadFlush>();

            _compressor = new IntCompressor(0, 256);
            SetFixedSize(_compressor.RequiredBits);
        }

        private readonly IntCompressor _compressor;

        private readonly IPlayerStateMapper _mapper;
        private readonly IEntityProvider _entityProvider;
        private readonly RemoteStateMachineLogger _logger;
        private readonly Dictionary<PlayerStateDefinition, IPlayerRemoteState> _states;
        private readonly Dictionary<PlayerStateDefinition, IRemotePayloadFlush> _flushes;

        private IPlayerRemoteState _current;
        private IPlayerRemoteStatePayload _payload;

        private int _state;

        public void SetState(PlayerStateDefinition definition, IPlayerRemoteStatePayload payload = null)
        {
            _state = _mapper.GetId(definition);
            _payload = payload;

            MarkAsChanged();
        }

        public void RegisterState(PlayerStateDefinition definition, IPlayerRemoteState state)
        {
        }
        
        public void RegisterState(ILifetime lifetime, PlayerStateDefinition definition, IPlayerRemoteState state)
        {
            _states.Add(definition, state);

            _logger.OnStateRegistered(_mapper.GetId(definition), definition.name);

            lifetime.ListenTerminate(() =>
            {
                _states.Remove(definition);

                _logger.OnStateUnregistered(_mapper.GetId(definition), definition.name);
            });
        }

        public void RegisterFlush(PlayerStateDefinition definition, IRemotePayloadFlush flush)
        {
            _flushes.Add(definition, flush);
        }

        public void UnregisterFlush(PlayerStateDefinition definition)
        {
            _flushes.Remove(definition);
        }

        public override void Serialize(RagonBuffer buffer)
        {
            _logger.OnSerialize(_state, _mapper.GetDefinition(_state).name);

            var compressed = _compressor.Compress(_state);

            buffer.Write(compressed, _compressor.RequiredBits);

            if (_payload == null)
            {
                buffer.WriteBool(false);
            }
            else
            {
                buffer.WriteBool(true);
                _payload.Serialize(buffer);
            }
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            var havePayload = buffer.ReadBool();
            var definition = _mapper.GetDefinition(_state);

            if (_entityProvider.IsMine == true)
            {
                if (havePayload == true)
                    _flushes[definition].Flush(buffer);

                return;
            }

            _state = _compressor.Decompress(compressed);
            _logger.OnDeserialize(_state, definition.name);

            _current?.Break();
            _current = _states[definition];
            _current?.Enter(buffer);
        }
    }
}