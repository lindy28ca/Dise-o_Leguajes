using System.IO;
using UnityEngine;

public static class SaveData
{
    public static string Load(string saveFile)
    {
        string combinepath = CombinePath(saveFile);
        string json = "";

        if (File.Exists(combinepath))
        {
            json = File.ReadAllText(combinepath);
            Debug.Log("Save file loaded " + combinepath);
        }
        else
        {
            Debug.LogWarning("Save file does not exist");
        }

        return json;
    }

    public static void Save(string saveFile, string json)
    {
        string combinepath = CombinePath(saveFile);
        StreamWriter sw = File.CreateText(combinepath);
        sw.Close();
        File.WriteAllText(combinepath, json);
    }

    private static string CombinePath(string saveFile)
    {
        string combinepath = Application.streamingAssetsPath + "/" + saveFile;
        return combinepath;
    }
}

