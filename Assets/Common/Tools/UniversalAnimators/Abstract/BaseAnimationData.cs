using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Abstract
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Common/Animator/Animation")]
    public class BaseAnimationData : ScriptableObject, IAnimationData
    {
        [SerializeField] private AnimationClip _clip;
        [SerializeField] private float _time;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private LayerDefinition _layer;

        public AnimationClip Clip => _clip;
        public float Time => _time;
        public float FadeDuration => _fadeDuration;
        public int Layer => _layer.Value;

        public IAnimation CreateAnimation()
        {
            var data = new AnimationData(_clip, _fadeDuration, _time, _layer.Value);
            var animation = new BaseAnimation(data);
            return animation;
        }
    }
}