using System;
using System.Collections.Generic;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Editor;
using GamePlay.Enemies.Services.Spawn.Definition.Runtime;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Enemies.Spawn.Processor.Definition.ToggleButtons.Runtime;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Processor.Definition.ToggleButtons.Editor
{
    [ReadOnlyDictionaryPriority]
    public class ToggleButtonsAttributeDrawer : OdinAttributeDrawer<EnemyToggleAttribute>
    {
        private readonly Dictionary<IEnemyDefinition, Texture> _icons = new();

        public override bool CanDrawTypeFilter(Type type)
        {
            return true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            var switchResolver =
                ValueResolver.Get<EnemyTypesDictionary>(
                    Property,
                    EnemyToggleAttribute.SwitchesName)
                    .GetValue();

            var registries = new List<EnemyDefinitionsRegistryFactory>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(EnemyDefinitionsRegistryFactory)}");

            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<EnemyDefinitionsRegistryFactory>(assetPath);

                if (asset == null)
                    continue;

                registries.Add(asset);
            }

            var registry = registries[0];

            foreach (var definition in registry.Definitions)
            {
                _icons[definition] = definition.EditorData.EditorIcon;
                    
                switchResolver.TryAdd((EnemyDefinition)definition, false);
            }
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            label.text = "";

            SirenixEditorGUI.GetFeatureRichControlRect(label,
                Mathf.CeilToInt(EditorGUIUtility.singleLineHeight * 3f),
                out var _, out var _, out var valueRect);

            var count = _icons.Count;
            var xPosition = valueRect.xMin;
            var width = valueRect.width / count;

            valueRect.width = width;

            var style = SirenixGUIStyles.Button;

            var switchResolver =
                ValueResolver.Get<EnemyTypesDictionary>(Property, EnemyToggleAttribute.SwitchesName).GetValue();

            foreach (var (type, icon) in _icons)
            {
                var isPressed = switchResolver[(EnemyDefinition)type];

                if (isPressed == false)
                    GUI.backgroundColor = Color.white;
                else
                    GUI.backgroundColor = Color.gray;

                valueRect.position = new Vector2(xPosition, valueRect.position.y);

                if (GUI.Button(valueRect, icon, style) == true)
                    switchResolver[(EnemyDefinition)type] = !switchResolver[(EnemyDefinition)type];

                xPosition += width;
            }
        }
    }
}