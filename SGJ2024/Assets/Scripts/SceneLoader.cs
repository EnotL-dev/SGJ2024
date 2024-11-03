using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scene_name;
    private void Start()
    {
        SceneManager.LoadScene(scene_name);
    }
}
