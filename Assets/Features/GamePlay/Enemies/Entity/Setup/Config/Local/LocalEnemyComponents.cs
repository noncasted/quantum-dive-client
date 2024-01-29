using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Config.Local
{
    public abstract class LocalEnemyComponents : ScriptableObject
    {
        public abstract IEnemyComponentFactory[] GetAssets();
    }
}