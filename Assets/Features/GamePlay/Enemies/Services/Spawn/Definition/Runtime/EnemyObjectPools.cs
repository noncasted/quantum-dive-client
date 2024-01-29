using Common.Tools.ObjectsPools.Runtime.Abstract;

namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public readonly struct EnemyObjectPools
    {
        public EnemyObjectPools(IAsyncObjectsPool local, IAsyncObjectsPool remote)
        {
            Local = local;
            Remote = remote;
        }
        
        public readonly IAsyncObjectsPool Local;
        public readonly IAsyncObjectsPool Remote;
    }
}