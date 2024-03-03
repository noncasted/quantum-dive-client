namespace Internal.Scenes.Data
{
    public interface ISceneAsset
    {
        public string Name { get; }
        public SceneAssetReference Reference { get; }
    }
}