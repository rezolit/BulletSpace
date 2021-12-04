using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ThinkingPlaceableInspector), true)]
public class ThinkingPlaceableInspector : Editor
{
	public override VisualElement CreateInspectorGUI()
	{
		VisualElement container = new VisualElement();

		SerializedProperty it = serializedObject.GetIterator();
		it.Next(true);

		while (it.NextVisible(false)) {
			PropertyField prop = new PropertyField(it);
			prop.SetEnabled(it.name != "m_Script");
			container.Add(prop);
		}

		return container;
	}
}
