using Guild;
using UnityEngine;

public class ActivateMover : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject.FindWithTag("Player").GetComponent<Mover>().enabled = true;
        gameObject.SetActive(false);       
    }
}
