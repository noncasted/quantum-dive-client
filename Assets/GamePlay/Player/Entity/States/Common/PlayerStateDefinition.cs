using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Common
{
    public abstract class PlayerStateDefinition : ScriptableObject
    {
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;

        public bool IsTransitable(PlayerStateDefinition definition)
        {
            foreach (var transition in _transitions)
                if (definition == transition)
                    return true;

            return false;
        }
    }
}