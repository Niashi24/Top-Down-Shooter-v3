using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System.Linq;

public class ObjectSearchProvider : ScriptableObject, ISearchWindowProvider
{
    System.Type assetType;
    public SerializedProperty serializedProperty;
    public ObjectSearchProvider(System.Type assetType, SerializedProperty serializedProperty) {
        this.assetType = assetType;
        this.serializedProperty = serializedProperty;
    }

    public ObjectSearchProvider Set(System.Type assetType, SerializedProperty serializedProperty) {
        this.assetType = assetType;
        this.serializedProperty = serializedProperty;
        return this;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context) {
        serializedProperty.objectReferenceValue = (UnityEngine.Object)SearchTreeEntry.userData;
        serializedProperty.serializedObject.ApplyModifiedProperties();
        return true;
    }

    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) {
        List<SearchTreeEntry> list = new List<SearchTreeEntry>();

        string[] assetGuids = AssetDatabase.FindAssets($"t:{assetType.Name}");
        List<string> paths = new List<string>();
        foreach(string guid in assetGuids)
            paths.Add(AssetDatabase.GUIDToAssetPath(guid));

        paths.OrderBy(x => x);
        paths = paths.Where(x => x.Contains("Assets/Variables/")).ToList();
        //paths.ForEach(x => Debug.Log(x));

        List<string> groups = new List<string>();
        foreach(string item in paths) {
            string[] entryTitle = item.Split('/');
            string groupName = "";
            for (int i = 0; i < entryTitle.Length - 1; i++) {
                groupName += entryTitle[i];
                if (!groups.Contains(groupName))
                {
                    list.Add(new SearchTreeGroupEntry(new GUIContent(entryTitle[i]), i+1));
                    groups.Add(groupName);
                }
                groupName += "/";
            }
        
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(item);
            SearchTreeEntry entry = new SearchTreeEntry(new GUIContent(entryTitle.Last(), EditorGUIUtility.ObjectContent(obj, obj.GetType()).image));
            entry.level = entryTitle.Length;
            entry.userData = obj;
            list.Add(entry);
        }

        return list;
    }
}
