using System.IO;
using UnityEditor;
using UnityEngine;

public class ProgressDataEditor : EditorWindow
{
    public ProgressData progressData;
    [MenuItem("Window/Progress Data Editor")]
    static void Init()
    {
        GetWindow(typeof(ProgressDataEditor)).Show();
    }

    private void OnGUI()
    {
        if (progressData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("progressData");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save Data"))
            {
                SaveGameData();
            }
        }
        if (GUILayout.Button("Load Data"))
        {
            LoadGameData();
        }
        if (GUILayout.Button("Crete new Data"))
        {
            CreateNewData();
        }
    }

    private void SaveGameData()
    {
        string filePath = EditorUtility.SaveFilePanel("Select Save Data file", Application.streamingAssetsPath, "", "json");
        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonUtility.ToJson(progressData);
            File.WriteAllText(filePath, dataAsJson);
        }
    }

    private void LoadGameData()
    {
        string filePath = EditorUtility.OpenFilePanel("Select Save Data file", Application.streamingAssetsPath, "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            progressData = JsonUtility.FromJson<ProgressData>(dataAsJson);
        }
    }

    private void CreateNewData()
    {
        progressData = new ProgressData();
    }
}