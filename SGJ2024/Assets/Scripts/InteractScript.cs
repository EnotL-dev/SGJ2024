using Guild;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private GameObject[] activateObjs;
    private Mover mover;
    private bool inZone;

    private void Awake()
    {
        mover = GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inZone && mover.enabled)
            {
                show_objs();
                mover.enabled = false;
            }
        }
    }

    void show_objs()
    {
        foreach(GameObject obj in activateObjs)
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inZone = false;
        }
    }
}
