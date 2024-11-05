using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BattleSystem;

public class DropAndDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool BlockGetting { get; set; } = false;
    [HideInInspector] public CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    [SerializeField] private ItemTrower _itemTrower;
    [HideInInspector] public Transform mySlot;
    public int id_item = 0;
    public int durability_item = 0;
    [SerializeField] private AudioClip takeitem_sound;

    [Header("Требует данный эллемент для боев")]
    [SerializeField] private RaycastElementsUI raycastElementsUI;

    private AudioSource audioSourceInventory;

    private void Start()
    {
      //  _itemTrower = FindAnyObjectByType<ItemTrower>();
        audioSourceInventory = GameObject.FindWithTag("AudioSoundInventory").GetComponent<AudioSource>();
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

        audioSourceInventory.PlayOneShot(takeitem_sound);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
        if (_itemTrower != null) // Выбрасывание на поле боя
        {
            List<GameObject> uiElementsUnderMouse = raycastElementsUI.GetUIElementsUnderMouse();

            if (uiElementsUnderMouse.Count < 1 && !BlockGetting)
            {
                _itemTrower.Launch(new ItemContainer(id_item, durability_item));
                InventoryManager inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
                inventoryManager.removeItem(mySlot.GetComponent<Image>());
            }
        }
    }
}
