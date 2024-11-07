using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static readonly string filePath;

    static SaveManager()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        filePath = Path.Combine(documentsPath, "SirKnightData", "playerData.json");

        // Создаём директорию, если её нет
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
    }

    public static void SavePlayerData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Данные игрока сохранены в файл: " + filePath);
        loging(data);
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Данные игрока загружены из файла: " + filePath);
            loging(data);
            return data;
        }

        Debug.LogWarning("Файл данных игрока не найден.");
        return null;
    }

    public static void ClearPlayerData()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Файл данных игрока удален.");
        }
    }

    private static void loging(PlayerData data)
    {
        string logData = $"Уровень: {data.lv}, ХП сейчас: {data.hp}, Срезаны ХП?: {data.halfHp}, Деньги: {data.money}, Дракон поврежден?: {data.dragon_was_damaged}\n";
        if(data.items.Count > 0)
        {
            logData += "Предметы: ";
            foreach(DoubleList item in data.items)
            {
                logData += $"{item.id} {item.durability} ";
            }
        }

        logData += $"Убитые монстры: гоблины {data.killedMonsters.goblins} скелеты {data.killedMonsters.skeletons} пауки {data.killedMonsters.spiders}грифоны {data.killedMonsters.grifon} волки {data.killedMonsters.wolfs}" +
            $" стражи {data.killedMonsters.guardians} исчадия {data.killedMonsters.exodus}";
        
        Debug.Log(logData);
    }
}
