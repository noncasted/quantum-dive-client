﻿using Common.Tools.UniversalAnimators.Old.Animations.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Old.Animations.Implementations.Native
{
    [InlineEditor]
    public abstract class NativeAnimationFactory : ScriptableObject
    {
        [SerializeField] private string _stateName;

        public AnimationData CreateData()
        {
            var data = new AnimationData(1f, _stateName);
            return data;
        }
    }
}