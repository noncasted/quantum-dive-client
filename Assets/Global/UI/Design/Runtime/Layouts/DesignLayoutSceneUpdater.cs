using UnityEngine;

namespace Global.UI.Design.Runtime.Layouts
{
    public class DesignLayoutSceneUpdater : UnityEditor.AssetModificationProcessor
    {
        public static string[] OnWillSaveAssets(string[] paths)
        {
            var roots =
                Object.FindObjectsByType<DesignLayoutRoot>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            foreach (var root in roots)
                root.ForceRecalculate();

            return paths;
        }
    }
}