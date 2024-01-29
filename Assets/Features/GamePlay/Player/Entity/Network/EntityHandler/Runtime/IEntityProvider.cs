namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    public interface IEntityProvider
    {
        int Id { get; }
        bool IsAttached { get; }
        bool IsMine { get; }
    }
}