using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject makeSaveObj;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject transitObj;
    [SerializeField] private GameObject reversObj;
    public void startGame()
    {
        makeSaveObj.SetActive(true);
        sceneLoader.scene_name = "Dialog0";
        transitObj.SetActive(true);
        reversObj.SetActive(false);
    }

    public void continueGame()
    {
        PlayerData loadData = SaveManager.LoadPlayerData();
        if(loadData == null)
        {
            startGame();
        }
        else
        {
            sceneLoader.scene_name = "Guild";
            transitObj.SetActive(true);
            reversObj.SetActive(false);
        }
    }

    public void quit()
    {
        Application.Quit();
    }
}
