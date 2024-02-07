
namespace GamePlay.Enemies.Services.Spawn.Definition.Runtime
{
    public interface IEnemyDefinition
    {
        IEnemyIdentification Identification { get; }
        IEnemyConfiguration Configuration { get; }        
        IEnemyEditorData EditorData { get; }
    }
}