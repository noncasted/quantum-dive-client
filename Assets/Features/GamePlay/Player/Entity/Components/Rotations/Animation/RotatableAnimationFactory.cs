using System.Collections.Generic;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameSequence;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Animation
{
    public abstract class RotatableAnimationFactory : ScriptableObject
    {
        [SerializeField] [Indent] private AnimationData _data;

        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _up = new();
        
        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _sideBack = new();
        
        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _side = new();
        
        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _sideFace = new();
        
        [SerializeField] [NestedScriptableObjectList]
        private List<AnimationFrameData> _down = new();

        protected AnimationData Data => _data;
        
        public IReadOnlyList<IFrameData> Up => _up;
        public IReadOnlyList<IFrameData> SideBack => _sideBack;
        public IReadOnlyList<IFrameData> Side => _side;
        public IReadOnlyList<IFrameData> SideFace => _sideFace;
        public IReadOnlyList<IFrameData> Down => _down;

        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _spritesUp;
        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _spritesSideBack;
        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _spritesSide;
        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _spritesSideFace;
        [SerializeField] [FoldoutGroup("Create")]
        private Sprite[] _spritesDown;
        
        [SerializeField] [FoldoutGroup("Create")]
        private string _animationName;

        [Button] [FoldoutGroup("Create")]
        private void CreateAnimation()
        {
            _up.Clear();
            _sideBack.Clear();
            _side.Clear();
            _sideFace.Clear();
            _down.Clear();
            
            DeleteAll();

            ConvertSprites(_spritesUp, _up, PlayerOrientation.Up);
            ConvertSprites(_spritesSideBack, _sideBack, PlayerOrientation.SideBack);
            ConvertSprites(_spritesSide, _side, PlayerOrientation.Side);
            ConvertSprites(_spritesSideFace, _sideFace, PlayerOrientation.SideBack);
            ConvertSprites(_spritesDown, _down, PlayerOrientation.Down);
        }

        private void ConvertSprites(Sprite[] sprites, List<AnimationFrameData> target, PlayerOrientation orientation)
        {
            var orientationName = orientation.ConvertToString();
            
            for (var i = 0; i < sprites.Length; i++)
            {
                var frame = CreateInstance<AnimationFrameData>();

                frame.name = $"{_animationName}_{orientationName}_{i}";
                frame.Setup(sprites[i]);
                
#if UNITY_EDITOR
                AssetDatabase.Refresh();
                AssetDatabase.AddObjectToAsset(frame, this);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
#endif

                target.Add(frame);
            }
            
#if UNITY_EDITOR
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }

        [Button] [FoldoutGroup("Destroy")]
        private void DeleteAll()
        {
#if UNITY_EDITOR
            var path = AssetDatabase.GetAssetPath(this);
            var objects = AssetDatabase.LoadAllAssetRepresentationsAtPath(path);

            foreach (var target in objects)
                DestroyImmediate(target, true);
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }
    }
}