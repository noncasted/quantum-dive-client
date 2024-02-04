using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Config.Remote
{
    public abstract class RemoteEnemyComponents : ScriptableObject
    {
        public abstract IComponentFactory[] GetAssets();
    }
}