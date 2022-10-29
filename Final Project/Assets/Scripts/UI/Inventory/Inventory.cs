using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private Item[] inventoryArray = new Item[4];

    public Item[] inventory
    {
        get { return inventoryArray;  }
        set { inventoryArray = value; UpdateUI(); }
    }

    public Image itemIcon;
    public TextMeshProUGUI qtyTextComp;

    public Sprite emptyItemSprite;

    //public void Initialize()
    //{
    //    //Transform child = transform.GetChild(0).GetChild(0);
    //    //itemIcon = child.Find("ItemImage").GetComponent<Image>();
    //    //qtyTextComp = child.Find("Background").GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    //    print(qtyTextComp);
    //}

    private void UpdateUI()
    {
        /*for (int i = 0; i < inventory.Length; i++) // For multi-Item Inventory
        {
            if (CheckSlot(0))
            {
                itemIcon.sprite = inventory[0].sprite;
                qtyTextComp.text = inventory[0].quantity.ToString();
            }
            else
            {
                itemIcon.sprite = emptyItemSprite;
                qtyTextComp.text = "00";
            }
        }*/

        if (CheckSlot(0))   // For single item Inventory
        {
            itemIcon.sprite = inventory[0].sprite;
            qtyTextComp.text = inventory[0].quantity.ToString();
        } else
        {
            itemIcon.sprite = emptyItemSprite;
            qtyTextComp.text = "00";
        }

    }

    public int getItemSlot(string ItemName)
    {
        int slot = -1;
        try
        {
            slot = Array.FindIndex(inventory, element => element.objectName == ItemName);
        }
        catch(Exception)
        {
            //print("ItemSlot Failed");
            return -1;
        }
        //print("Itemslot: " + slot);
        return slot;
    }
    private bool CheckSlot(int slotNumber)
    {
        if (inventory[slotNumber] == null)
            return false;
        return true;
    }
    private int CheckForAvailableSlot()
    {
        for (int i = 0; i <= inventory.Length - 1; i++)
        {
            if (!CheckSlot(i))
                return i;
        }
        return -1;
    }
    public bool AddItem(Item item)
    {
        int index = getItemSlot(item.objectName);
        if (index != -1)
        {
            if (!item.stackable)
            {
                //print("Item is already in array");
                return false;
            }
            inventory[index].quantity += item.quantity;
            UpdateUI();
            return true;
        }

        int availableSlot = CheckForAvailableSlot();

        if (availableSlot == -1)
        {
           // print("No Available slots");
            return false;
        }
        //print("Inventory Slot: " + availableSlot);
        //print(item.sprite);
        inventory[availableSlot] = item;
        UpdateUI();
        return true;
    }
    public void RemoveItem(Item item)
    {
        // inventory.find and remove item
    }
    /*private bool CheckForItem(Item item)
    {
        Item existingItem = getItem(item.objectName);
        if (existingItem != null)
        {
            return true;
        }
        return false;
    }*/
}