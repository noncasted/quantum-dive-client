using System;
using System.Collections.Generic;
using GamePlay.Enemies.Entity.Definition.Asset;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;
using GamePlay.Enemies.Services.Spawn.Registry.Runtime;
using GamePlay.Enemies.Spawn.Processor.Definition.Probability.Runtime;
using GamePlay.Enemies.Spawn.Processor.Definition.ToggleButtons.Runtime;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Enemies.Spawn.Processor.Definition.Probability.Editor
{
    public class ProbabilityAttributeDrawer : OdinAttributeDrawer<EnemyProbabilityAttribute>
    {
        private readonly Dictionary<IEnemyDefinition, Texture> _icons = new();
        private readonly Dictionary<int, IEnemyDefinition> _indexMap = new();

        private bool _isDragged;
        private int _selectedId;
        private EnemyDefinitionsRegistryFactory _registry;

        protected override void Initialize()
        {
            base.Initialize();

            var switchResolver =
                ValueResolver.Get<EnemyTypesDictionary>(Property, "_switches").GetValue();

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

            _registry = registries[0];

            foreach (var definition in _registry.Definitions)
            {
                _icons[definition] = definition.EditorData.EditorIcon;
                    
                switchResolver.TryAdd((EnemyDefinition)definition, false);
            }
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            var values =
                ValueResolver.Get<ProbabilityDictionary>(Property, "_values").GetValue();

            var switches =
                ValueResolver.Get<EnemyTypesDictionary>(Property, "_switches").GetValue();

            void DistributeValues()
            {
                var delta = 1f / values.Count;

                foreach (var target in _registry.Definitions)
                {
                    if (values.ContainsKey((EnemyDefinition)target) == false)
                        continue;

                    values[(EnemyDefinition)target] = delta;
                }
            }

            foreach (var (type, value) in switches)
            {
                if (value == true && values.ContainsKey(type) == false)
                {
                    if (values.Count == 0)
                    {
                        values[type] = 1f;
                        break;
                    }

                    values.Add(type, 0f);

                    DistributeValues();
                }

                if (value == false && values.ContainsKey(type) == true)
                {
                    values.Remove(type);

                    DistributeValues();
                }
            }

            if (values.Count == 0)
            {
                _isDragged = false;
                return;
            }

            var rect = EditorGUILayout.GetControlRect(false, 100);

            if (Mathf.Approximately(rect.width, 1f) == true)
                return;

            var rects = DrawEntries(rect, values);

            DrawSelection(rect, rects, values);
        }

        private Rect[] DrawEntries(Rect rect, ProbabilityDictionary values)
        {
            SirenixEditorGUI.DrawSolidRect(rect, Color.black);

            var style = new GUIStyle();
            style.alignment = TextAnchor.UpperCenter;

            var totalWidth = rect.xMax - rect.xMin;
            var offset = rect.xMin;
            var index = 0;

            var rects = new Rect[values.Count];

            var current = rect;

            foreach (var (type, value) in values)
            {
                var width = totalWidth * value;

                if (index == 0)
                {
                    var target = current.SetXMax(width + offset);

                    SirenixEditorGUI.DrawSolidRect(target, GetColor(index));

                    current = target;
                }
                else
                {
                    var min = current.xMax;
                    var target = current.SetXMin(min).SetXMax(min + width);

                    SirenixEditorGUI.DrawSolidRect(target, GetColor(index));

                    current = target;
                }
                
                var icon = _icons[type];
                var iconRect = current.AlignCenterX(icon.width).AlignCenterY(icon.height);
                iconRect.y -= current.height * 0.1f;
                GUI.Label(iconRect, _icons[type]);

                var textPosition = current.AlignCenterX(current.width).AlignBottom(current.height * 0.4f);
                var textStyle = new GUIStyle(GUI.skin.label);
                textStyle.alignment = TextAnchor.MiddleCenter;
                GUI.skin.label.fontSize = 24;
                GUI.Label(textPosition, $"{Mathf.FloorToInt(value * 100)}%", textStyle);

                rects[index] = current;
                _indexMap[index] = type;

                index++;
            }

            return rects;
        }

        private void DrawSelection(Rect rect, Rect[] rects, ProbabilityDictionary values)
        {
            Array.Resize(ref rects, rects.Length - 1);

            for (var i = 0; i < rects.Length; i++)
            {
                var current = rects[i];
                rects[i] = new Rect(current.xMax - 16, rect.y, 32, 32);

                GUI.Label(rects[i], EditorIcons.Eject.Raw);
            }

            var currentEvent = Event.current;

            if (currentEvent.type == EventType.MouseUp)
            {
                _isDragged = false;
                return;
            }

            for (var i = 0; i < rects.Length; i++)
            {
                if (rects[i].Contains(currentEvent.mousePosition) == false)
                    continue;

                if (currentEvent.type != EventType.MouseDown || currentEvent.button != 0)
                    continue;

                _isDragged = true;
                _selectedId = i;
                break;
            }

            if (_isDragged == false)
                return;

            var originX = rects[_selectedId].center.x;

            var position = Mathf.Clamp(currentEvent.mousePosition.x, rect.xMin, rect.xMax);
            var target = position / rect.width;

            originX = Mathf.Clamp(originX, rect.xMin, rect.xMax);
            var origin = originX / rect.width;

            var delta = target - origin;

            var selected = (EnemyDefinition)_indexMap[_selectedId];
            var next = (EnemyDefinition)_indexMap[_selectedId + 1];

            var selectedValue = values[selected];
            var nextValue = values[next];

            values[selected] += delta;
            values[next] -= delta;

            if (values[selected] <= 0.02f || values[next] <= 0.02f)
            {
                values[selected] = selectedValue;
                values[next] = nextValue;
            }
        }

        private Color GetColor(int index)
        {
            var colors = GetColorPalette();

            index %= colors.Length;

            return colors[index];
        }

        private Color[] GetColorPalette()
        {
            foreach (var palette in ColorPaletteManager.Instance.ColorPalettes)
            {
                if (palette.Name != "Fall")
                    continue;

                return palette.Colors.ToArray();
            }

            return null;
        }
    }
}