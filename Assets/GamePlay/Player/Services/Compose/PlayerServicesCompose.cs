using System.Collections.Generic;
using GamePlay.Player.Services.Common;
using GamePlay.Player.Services.Factory.Factory.Runtime;
using GamePlay.Player.Services.List.Runtime;
using GamePlay.Player.Services.Mappers.Equipment.Runtime;
using GamePlay.Player.Services.Mappers.States.Runtime;
using GamePlay.Player.UI.Overlay.Runtime.Bootstrap;
using Internal.Scopes.Abstract.Instances.Services;
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
        [SerializeField] private PlayerListFactory _playerList;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _playerFactory,
            _playerEquipmentMapper,
            _playerStatesRegistry,
            _playerOverlay,
            _playerList
        };
    }
}