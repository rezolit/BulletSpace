using System;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.NRefactory.PrettyPrinter;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

public class LevelEditorWindow : EditorWindow
{
	[MenuItem("Tools/Level Editor Window")]
	public static void ShowWindow()
	{
		var window = GetWindow<LevelEditorWindow>();
		window.titleContent = new GUIContent("Level Editor");
		window.minSize = new Vector2(800, 600);
	}

	private void OnEnable()
	{
		VisualTreeAsset original =
			AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/InternalAssets/Editor/LevelEditorWindow.uxml");
		TemplateContainer treeAsset = original.CloneTree();
		rootVisualElement.Add(treeAsset);

		StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/InternalAssets/Editor/LevelEditorStyles.uss");
		rootVisualElement.styleSheets.Add(styleSheet);
		
		CreateLevelListView();
	}

	private void CreateLevelListView()
	{
		FindAllLevels(out LevelData[] levels);

		ListView levelList = rootVisualElement.Query<ListView>("level-list").First();
		levelList.makeItem = (() => new Label());
		levelList.bindItem = ((element, i) => (element as Label).text = levels[i].LevelName);

		levelList.itemsSource = levels;
		levelList.itemHeight = 16;
		levelList.selectionType = SelectionType.Single;

		levelList.onSelectionChange += (enumerable) => {
			foreach (Object it in enumerable) {
				Box levelBoxInfo = rootVisualElement.Query<Box>("level-info").First();
				levelBoxInfo.Clear();

				LevelData level = it as LevelData;

				SerializedObject serializedLevel = new SerializedObject(level);
				SerializedProperty levelProperty = serializedLevel.GetIterator();
				levelProperty.Next(true);

				while (levelProperty.NextVisible(false)) {
					PropertyField prop = new PropertyField(levelProperty);

					prop.SetEnabled(levelProperty.name != "m_Script");
					prop.Bind(serializedLevel);
					levelBoxInfo.Add(prop);

					if (levelProperty.name == "levelImage") {
						prop.RegisterCallback<ChangeEvent<UnityEngine.Object>>((evt =>
								LoadLevelImage(level.LevelImage.texture))
						);
					}
				}

				LoadLevelImage(level.LevelImage.texture);
			}
		};
	}

	private void FindAllLevels(out LevelData[] levels)
	{
		var guids = AssetDatabase.FindAssets("t:LevelData");

		levels = new LevelData[guids.Length];

		for (int i = 0; i < guids.Length; ++i) {
			var path = AssetDatabase.GUIDToAssetPath(guids[i]);
			levels[i] = AssetDatabase.LoadAssetAtPath<LevelData>(path);
		}
	}

	private void LoadLevelImage(Texture texture)
	{
		if (texture == null) {
			throw new Exception("Null texture");
		}
		var levelPreviewImage = rootVisualElement.Query<Image>("preview").First();
		levelPreviewImage.image = texture;
	}
}
