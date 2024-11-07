using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static readonly string filePath;

    static SaveManager()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "SirKnightData", "playerData.json");

        // ������ ����������, ���� � ���
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
    }

    public static void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("������ ������ ��������� � ����: " + filePath);
        loging(data);
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("������ ������ ��������� �� �����: " + filePath);
            loging(data);
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

    private static void loging(PlayerData data)
    {
        string logData = $"�������: {data.lv}, �� ������: {data.hp}, ������� ��?: {data.halfHp}, ������: {data.money}, ������ ���������?: {data.dragon_was_damaged}\n";
        if(data.items.Count > 0)
        {
            logData += "��������: ";
            foreach(DoubleList item in data.items)
            {
                logData += $"{item.id} {item.durability} ";
            }
        }

        logData += $"������ �������: ������� {data.killedMonsters.goblins} ������� {data.killedMonsters.skeletons} ����� {data.killedMonsters.spiders}������� {data.killedMonsters.grifon} ����� {data.killedMonsters.wolfs}" +
            $" ������ {data.killedMonsters.guardians} ������� {data.killedMonsters.exodus}";
        
        Debug.Log(logData);
    }
}
