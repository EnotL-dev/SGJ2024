using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite activeSlot;
    [SerializeField] private Sprite disableSlot;
    [Space(10)]
    [SerializeField] private Transform parent_for_information;
    [SerializeField] private GameObject panel;
    private GameObject _panel; //Для запоминания, чтобы удалять

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = activeSlot;
        spawnPanel();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = disableSlot;
        if(_panel != null)
        {
            Destroy(_panel);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Transform child = transform.GetChild(0);

            var item = eventData.pointerDrag.transform;
            child.gameObject.GetComponent<DropAndDrag>().mySlot = item.gameObject.GetComponent<DropAndDrag>().mySlot;
            child.SetParent(item.gameObject.GetComponent<DropAndDrag>().mySlot);
            child.localPosition = Vector3.zero;

            item.SetParent(transform);
            item.localPosition = Vector3.zero;
            item.gameObject.GetComponent<DropAndDrag>().mySlot = transform;

            if (_panel != null)
            {
                Destroy(_panel);
            }
        }
    }

    private void spawnPanel()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            _panel = Instantiate(panel, parent_for_information);

            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parent_for_information as RectTransform,
                screenPoint,
                Camera.main,
                out Vector2 localPoint
            );

            localPoint.y += 105;
            _panel.GetComponent<RectTransform>().localPosition = localPoint;

            int id_item = transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().id_item;
            int durability_item = transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().durability_item;
            _panel.GetComponent<InformationPanelScript>().informate(id_item, durability_item);
        }
    }
}
