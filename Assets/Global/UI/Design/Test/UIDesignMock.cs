using Cysharp.Threading.Tasks;
using Global.Common.Mocks.Runtime;
using Global.UI.Nova.InputManagers.Abstract;
using UnityEngine;
using VContainer;

namespace Global.UI.Design.Test
{
    public class UIDesignMock : MockBase
    {
        [SerializeField] private Camera _camera;
        
        public override async UniTaskVoid Process()
        {
            var result = await BootstrapGlobal();

            result.Resolver.Resolve<IUIInputHandler>().SetCamera(_camera);
        }
    }
}