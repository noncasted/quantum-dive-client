
namespace GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract
{
    public interface IEnemyDefinition
    {
        IEnemyIdentification Identification { get; }
        IEnemyConfiguration Configuration { get; }        
        IEnemyEditorData EditorData { get; }
    }
}