﻿using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Player.Services.Common;
using GamePlay.Player.Services.Factory.Factory.Runtime;
using GamePlay.Player.Services.Mappers.Equipment.Runtime;
using GamePlay.Player.Services.Mappers.States.Runtime;
using GamePlay.Player.UI.Overlay.Runtime.Bootstrap;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "PlayerServicesCompose",
        menuName = PlayerServicesRoutes.Root + "Compose")]
    public class PlayerServicesCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private PlayerFactoryServiceFactory _playerFactory;
        [SerializeField] private PlayerEquipmentMapperFactory _playerEquipmentMapper;
        [SerializeField] private PlayerStateMapperFactory _playerStatesRegistry;
        [SerializeField] private PlayerOverlayFactory _playerOverlay;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _playerFactory,
            _playerEquipmentMapper,
            _playerStatesRegistry,
            _playerOverlay
        };
    }
}