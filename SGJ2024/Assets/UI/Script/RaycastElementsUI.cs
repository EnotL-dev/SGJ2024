using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastElementsUI : MonoBehaviour
{
    [Header("������ ����� ����������� �� ���������")]
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;

    public List<GameObject> GetUIElementsUnderMouse()
    {
        List<GameObject> uiElements = new List<GameObject>();

        // ������� PointerEventData ��� ������� ������� �����
        PointerEventData pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        // ������ ��� �������� ���� �����������
        List<RaycastResult> results = new List<RaycastResult>();

        // ��������� Raycast
        raycaster.Raycast(pointerEventData, results);

        // ��������� ��� ��������� ������� UI
        foreach (RaycastResult result in results)
        {
            uiElements.Add(result.gameObject);
        }

        return uiElements;
    }
}
