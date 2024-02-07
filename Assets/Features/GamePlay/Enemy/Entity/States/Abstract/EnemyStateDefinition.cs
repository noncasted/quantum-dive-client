using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.States.Abstract
{
    public abstract class EnemyStateDefinition : ScriptableObject
    {
        [SerializeField] [Indent] private EnemyStateDefinition[] _transitions;
        [SerializeField] [Indent] private bool _isBackground;

        public bool IsBackground => _isBackground;

        public bool IsTransitable(EnemyStateDefinition definition)
        {
            foreach (var transition in _transitions)
                if (definition == transition)
                    return true;

            return false;
        }
    }
}