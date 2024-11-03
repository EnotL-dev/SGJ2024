using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CellDungeon : MonoBehaviour
{
    [SerializeField] private DungeonManager dungeonManager;
    [Space(20)]
    [SerializeField] private int lvScene = 1;
    [SerializeField] private Light2D[] lightSpots;

    private void Awake()
    {
        fadeLights();
    }

    void OnMouseEnter()
    {
        appearLights();
    }

    void OnMouseExit()
    {
        fadeLights();
    }

    private void appearLights()
    {
        lightSpots[0].intensity = 7f;
        lightSpots[1].intensity = 9f;
    }

    private void fadeLights()
    {
        lightSpots[0].intensity = 5f;
        lightSpots[1].intensity = 7f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                dungeonManager.loadLevel(lvScene);
            }
        }
    }
}
