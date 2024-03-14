using Ragon.Protocol;

namespace Menu.Services.Network.PlayersLists.Runtime
{
    public readonly struct PlayerData
    {
        public PlayerData(string id, string name, bool isMaster)
        {
            Id = id;
            Name = name;
            IsMaster = isMaster;
        }
        
        public readonly string Id;
        public readonly string Name;
        public readonly bool IsMaster;

        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteString(Id);
            buffer.WriteString(Name);
            buffer.WriteBool(IsMaster);
        }

        public static PlayerData Deserialize(RagonBuffer buffer)
        {
            var id = buffer.ReadString();
            var name = buffer.ReadString();
            var isMaster = buffer.ReadBool();

            var data = new PlayerData(id, name, isMaster);

            return data;
        }
    }
}