using System;
using System.Collections.Generic;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace Menu.Network.PlayersLists.Runtime
{
    public class PlayersList : RagonProperty
    {
        public PlayersList() : base(0, true)
        {
            _list = new List<PlayerData>();
        }

        private readonly List<PlayerData> _list;
        private readonly IntCompressor _compressor = new(0, 128);

        public event Action<IReadOnlyList<PlayerData>> Updated;
        
        public IReadOnlyList<PlayerData> List => _list;

        public void Add(PlayerData data)
        {
            _list.Add(data);

            MarkAsChanged();
            
            Updated?.Invoke(_list);
        }

        public void Remove(string id)
        {
            foreach (var playerData in _list)
            {
                if (playerData.Id != id)
                    continue;

                _list.Remove(playerData);

                MarkAsChanged();

                Updated?.Invoke(_list);
                
                return;
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            var count = _list.Count;
            buffer.Write(_compressor.Compress(count), _compressor.RequiredBits);

            foreach (var data in _list)
                data.Serialize(buffer);
            
            Updated?.Invoke(_list);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            _list.Clear();
            var count = _compressor.Decompress(buffer.Read(_compressor.RequiredBits));

            for (var i = 0; i < count; i++)
            {
                var data = PlayerData.Deserialize(buffer);
                _list.Add(data);
            }
            
            Updated?.Invoke(_list);
        }
    }
}