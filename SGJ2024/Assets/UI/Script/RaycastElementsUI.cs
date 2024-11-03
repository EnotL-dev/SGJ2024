using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastElementsUI : MonoBehaviour
{
    [Header("Скрипт чинит выкидывание из инвентаря")]
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;

    public List<GameObject> GetUIElementsUnderMouse()
    {
        List<GameObject> uiElements = new List<GameObject>();

        // Создаем PointerEventData для текущей позиции мышки
        PointerEventData pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        // Список для хранения всех результатов
        List<RaycastResult> results = new List<RaycastResult>();

        // Выполняем Raycast
        raycaster.Raycast(pointerEventData, results);

        // Сохраняем все найденные объекты UI
        foreach (RaycastResult result in results)
        {
            uiElements.Add(result.gameObject);
        }

        return uiElements;
    }
}
