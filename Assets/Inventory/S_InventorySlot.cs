using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, deselectedColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = deselectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        S_InventoryItem draggedItem = eventData.pointerDrag.GetComponent<S_InventoryItem>();

        Transform slot = transform.Find("slot");

        //empty slot
        if (slot.childCount == 0)
        {
            draggedItem.parentAfterDrag = slot;
        }
        //slot might contain same item
        else
        {
            S_InventoryItem slotItem = slot.GetComponentInChildren<S_InventoryItem>();
            if (slotItem.item == draggedItem.item)
            {
                int totalCount = draggedItem.count + slotItem.count;
                int excessCount = totalCount - slotItem.maxCount;

                if (excessCount <= 0)
                {
                    slotItem.count = totalCount;
                    slotItem.RefreshCount();
                    Destroy(draggedItem.gameObject);
                }
                else
                {
                    slotItem.count = slotItem.maxCount;
                    slotItem.RefreshCount();

                    draggedItem.count = excessCount;
                    draggedItem.RefreshCount();
                }
            }
        }
    }
}
