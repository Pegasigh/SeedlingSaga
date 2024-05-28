using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class S_InventoryManager : MonoBehaviour
{
    public S_InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public GameObject inventoryMenu;
    public GameObject hotbarCanvas;
    private S_HotbarItem activeHotbarSlot;
    private S_HotbarItem leftHotbarSlot;
    private S_HotbarItem rightHotbarSlot;
    //private bool isActive;

    int selectedSlot = -1;

    private void Start()
    {
        activeHotbarSlot = hotbarCanvas.transform.GetChild(0).Find("ActiveItem").GetComponentInChildren<S_HotbarItem>();
        leftHotbarSlot = hotbarCanvas.transform.GetChild(0).Find("LeftItem").GetComponentInChildren<S_HotbarItem>();
        rightHotbarSlot = hotbarCanvas.transform.GetChild(0).Find("RightItem").GetComponentInChildren<S_HotbarItem>();

        changeSelectedSlot(0);

        inventoryMenu.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        //toggle GUI
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ///////////////////////////////////////////////////////////
            //isActive = !isActive;
            //inventoryMenu.SetActive(isActive);

            inventoryMenu.GetComponent<Canvas>().enabled = !inventoryMenu.GetComponent<Canvas>().enabled;
        }

        //scroll left through inventory
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedSlot > 0) changeSelectedSlot(selectedSlot - 1);
            else if (selectedSlot == -1 || selectedSlot == 0) changeSelectedSlot(inventorySlots.Length - 1);
        }

        //scroll right through inventory
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedSlot < inventorySlots.Length - 1) changeSelectedSlot(selectedSlot + 1);
            else if (selectedSlot == -1 || selectedSlot == inventorySlots.Length - 1) changeSelectedSlot(0);
        }

        // close inventory if open or put away held item if inventory is already closed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inventoryMenu.GetComponent<Canvas>().enabled) changeSelectedSlot(-1);
            else inventoryMenu.GetComponent<Canvas>().enabled = false;
        }

        UpdateHotbar();
    }

    public SO_Item GetSelectedItem(bool use)
    {
        S_InventoryItem item = inventorySlots[selectedSlot].GetComponentInChildren<S_InventoryItem>();
        if (item != null)
        {
            if (use)
            {
                item.count--;
                if (item.count <= 0)
                {
                    activeHotbarSlot.ClearSlot();
                    Destroy(item.gameObject);
                } 
                else
                {
                    item.RefreshCount();
                } 
            }
            return item.item;
        } 
        else return null;
    }

    void changeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0) inventorySlots[selectedSlot].Deselect();
        if (newValue >= 0) inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public void UpdateHotbar()
    {
        int activeIndex = selectedSlot;
        int leftIndex = selectedSlot - 1;
        if (leftIndex < 0) leftIndex = inventorySlots.Length - 1;
        int rightIndex = selectedSlot + 1;
        if (rightIndex >= inventorySlots.Length) rightIndex = 0;

        //active item slot
        if (activeIndex == -1)
        {
            activeHotbarSlot.ClearSlot();
        }
        else
        {
            S_InventoryItem activeItem = inventorySlots[activeIndex].GetComponentInChildren<S_InventoryItem>();
            if (activeItem != null)
            {
                activeHotbarSlot.RefreshSlot(activeItem.image, activeItem.count);
            }
            else activeHotbarSlot.ClearSlot();
        }
        

        //active item slot
        S_InventoryItem leftItem = inventorySlots[leftIndex].GetComponentInChildren<S_InventoryItem>();
        if (leftItem != null)
        {
            leftHotbarSlot.RefreshSlot(leftItem.image, leftItem.count);
        }
        else leftHotbarSlot.ClearSlot();

        //active item slot
        S_InventoryItem rightItem = inventorySlots[rightIndex].GetComponentInChildren<S_InventoryItem>();
        if (rightItem != null)
        {
            rightHotbarSlot.RefreshSlot(rightItem.image, rightItem.count);
        }
        else rightHotbarSlot.ClearSlot();
    }

    public bool AddItem(SO_Item item)
    {
        //finding inventorySlot with same item and less than maximum itemCount
        foreach (S_InventorySlot inventorySlot in inventorySlots)
        {
            S_InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<S_InventoryItem>();
            if (itemInSlot != null && 
                itemInSlot.item == item && 
                itemInSlot.count < itemInSlot.maxCount &&
                itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        //finding empty inventorySlot
        foreach (S_InventorySlot inventorySlot in inventorySlots)
        {
            S_InventoryItem itemInSlot = inventorySlot.GetComponentInChildren<S_InventoryItem>();
            if(itemInSlot == null) //no item in inventorySlot
            {
                SpawnNewItem(item, inventorySlot);
                return true;
            }
        }

        return false; //returns false if no empty inventorySlot is found
    }

    void SpawnNewItem(SO_Item item, S_InventorySlot inventorySlot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, inventorySlot.transform.Find("slot"));
        S_InventoryItem inventoryItem = newItem.GetComponent<S_InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

}
