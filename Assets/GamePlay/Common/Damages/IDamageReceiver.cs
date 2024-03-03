﻿using UnityEngine;

namespace GamePlay.Common.Damages
{
    public interface IDamageReceiver
    {
        float Radius { get; }
        Vector3 Position { get; }
        void ReceiveDamage(Damage damage);
    }
}