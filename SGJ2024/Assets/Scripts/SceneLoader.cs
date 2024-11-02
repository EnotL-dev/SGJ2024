using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int idScene;
    private void Start()
    {
        SceneManager.LoadScene(idScene);
    }
}
