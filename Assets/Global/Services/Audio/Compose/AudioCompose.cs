using System.Collections.Generic;
using Global.Audio.Common;
using Global.Audio.Listener.Runtime;
using Global.Audio.Player.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Audio.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalAudioCompose", menuName = GlobalAudioAssetsPaths.Root + "Compose")]
    public class AudioCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] [Indent] private GlobalAudioListenerFactory _listener;
        [SerializeField] [Indent] private GlobalAudioPlayerFactory _player;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _listener,
            _player
        };
    }
}