using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [System.Serializable]
    public class Cells
    {
        public GameObject closed;
        public GameObject passed;
        public GameObject active;
    }

    [SerializeField] private int lv = 1;
    [Space(20)]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip click_sound;
    [SerializeField] private Cells[] cells;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject transitObj;
    [SerializeField] private GameObject destroyReverseTransit;

    private void Awake()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        lv = playerData.lv;

        showCells();
    }

    private void showCells()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if(i == lv-1)
            {
                cells[i].closed.SetActive(false);
                cells[i].active.SetActive(true);
                cells[i].passed.SetActive(false);
            }
            if(i < lv-1)
            {
                cells[i].closed.SetActive(false);
                cells[i].active.SetActive(false);
                cells[i].passed.SetActive(true);
            }
            if(i > lv-1)
            {
                cells[i].closed.SetActive(true);
                cells[i].active.SetActive(false);
                cells[i].passed.SetActive(false);
            }
        }
    }

    public void loadLevel(int lvScene)
    {
        if (!cells[lvScene-1].closed.activeSelf && !transitObj.activeSelf)
        {
            audioSource.PlayOneShot(click_sound);

            string scene_name = "Battle"+ lvScene;
            sceneLoader.scene_name = scene_name;

            destroyReverseTransit.SetActive(false);
            transitObj.SetActive(true);
        }
    }
}
