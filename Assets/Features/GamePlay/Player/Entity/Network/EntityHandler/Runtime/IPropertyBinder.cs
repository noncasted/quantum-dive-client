﻿using Ragon.Client;

namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    public interface IPropertyBinder
    {
        void BindProperty(RagonProperty property);
    }
}