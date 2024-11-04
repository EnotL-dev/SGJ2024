using UnityEngine;

public class RegenHpByActivate : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        int regen_hp = 100 + (playerData.lv * 50);
        PlayerData saveData = new PlayerData(playerData.lv, regen_hp, playerData.halfHp, playerData.money, playerData.items, playerData.killedMonsters, playerData.dragon_was_damaged);
        SaveManager.SavePlayerData(saveData);
        Debug.Log("’п востановлено");
        gameObject.SetActive(false);
    }
}
