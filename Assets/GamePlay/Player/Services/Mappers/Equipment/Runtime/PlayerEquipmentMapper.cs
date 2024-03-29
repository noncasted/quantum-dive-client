﻿using System.Collections.Generic;
using Common.DataTypes.Runtime.Collections;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Services.Mappers.Equipment.Abstract;

namespace GamePlay.Player.Services.Mappers.Equipment.Runtime
{
    public class PlayerEquipmentMapper : IPlayerEquipmentMapper
    {
        public PlayerEquipmentMapper(IReadOnlyList<IEquipmentConfig> factories)
        {
            _configs = new DoubleSideIntDictionary<IEquipmentConfig>(factories);
        }

        private readonly IDoubleSideDictionary<int, IEquipmentConfig> _configs;
        
        public int GetId(IEquipmentConfig config)
        {
            return _configs.Keys[config];
        }

        public IEquipmentConfig GetFactory(int id)
        {
            return _configs.Values[id];
        }
    }
}