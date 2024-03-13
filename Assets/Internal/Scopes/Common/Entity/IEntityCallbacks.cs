﻿using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Lifetimes;

namespace Internal.Scopes.Common.Entity
{
    public interface IEntityCallbacks
    {
        UniTask RunEnable(ILifetime lifetime);
        UniTask RunDisable();
    }
}