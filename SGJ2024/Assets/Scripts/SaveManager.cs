using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static readonly string filePath;

    static SaveManager()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "GameData", "playerData.json");

        // ������ ����������, ���� � ���
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
    }

    public static void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("������ ������ ��������� � ����: " + filePath);
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("������ ������ ��������� �� �����: " + filePath);
            return data;
        }

        Debug.LogWarning("���� ������ ������ �� ������.");
        return null;
    }

    public static void ClearPlayerData()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("���� ������ ������ ������.");
        }
    }
}
