﻿using Internal.Scopes.Abstract.Lifetimes;

namespace Common.Tools.UniversalAnimators.Old.Updaters.Runtime
{
    public interface IAnimatorsUpdater
    {
        void Register(ILifetime lifetime, IUpdatableAnimator animator);
    }
}