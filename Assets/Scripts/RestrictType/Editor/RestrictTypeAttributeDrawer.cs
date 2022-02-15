using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Experimental.GraphView;

[CustomPropertyDrawer(typeof(RestrictType))]
public class RestrictTypeAttributeDrawer: PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        position.width -= 60;
        var attrib = this.attribute as RestrictType;
        var fieldType = this.fieldInfo.FieldType;

        var obj = EditorGUI.ObjectField(position, label, property.objectReferenceValue, fieldType, true);
        if (obj != null && !attrib.objectType.IsInstanceOfType(obj))
        {
            if (obj is GameObject)
                obj = (obj as GameObject).GetComponent(attrib.objectType);
            else if (obj is Component)
                obj = (obj as Component).gameObject.GetComponent(attrib.objectType);
            else
                obj = null;
        }
        property.objectReferenceValue = obj;

        position.x += position.width;
        position.width = 60;
        if (GUI.Button(position, new GUIContent("Find")))
        {
            Type t = attrib.objectType;
            SearchWindow.Open(
                new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                ScriptableObject.CreateInstance<ObjectSearchProvider>().Set(t, property)
            );
        }
    }
}