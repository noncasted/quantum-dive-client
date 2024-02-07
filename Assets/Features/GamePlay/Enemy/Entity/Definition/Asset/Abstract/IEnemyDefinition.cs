
namespace GamePlay.Enemy.Entity.Definition.Asset.Abstract
{
    public interface IEnemyDefinition
    {
        IEnemyIdentification Identification { get; }
        IEnemyConfiguration Configuration { get; }        
        IEnemyEditorData EditorData { get; }
    }
}