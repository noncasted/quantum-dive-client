using System.Collections.Generic;
using GamePlay.Player.Common;
using GamePlay.Player.Factory.Factory.Runtime;
using GamePlay.Player.List.Runtime;
using GamePlay.Player.Mappers.Equipment.Runtime;
using GamePlay.Player.Mappers.States.Runtime;
using GamePlay.Player.UI.Overlay.Runtime.Bootstrap;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Compose
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