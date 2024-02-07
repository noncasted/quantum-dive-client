namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime
{
    public interface IEntityProvider
    {
        int Id { get; }
        bool IsAttached { get; }
        bool IsMine { get; }
    }
}