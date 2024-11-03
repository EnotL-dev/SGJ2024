using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BattleSystem;

public class DropAndDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private ItemTrower _itemTrower;
    [HideInInspector] public Transform mySlot;
    public int id_item = 0;
    public int durability_item = 0;

    private void Start()
    {
        _itemTrower = FindAnyObjectByType<ItemTrower>();
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        mySlot = gameObject.transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTranform = rectTransform.parent;
        slotTranform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
        if (_itemTrower != null)
        {// ������������ �� ���� ���
            _itemTrower.Launch(id_item);
            InventoryManager inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
            inventoryManager.removeItem(mySlot.GetComponent<Image>());
        }
    }
}
