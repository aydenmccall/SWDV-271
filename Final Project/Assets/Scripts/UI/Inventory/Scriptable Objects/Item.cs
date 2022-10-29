using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item
{
    public Item(string Name, Sprite Sprite, ItemType Type, bool Stackable = false, int Quantity = 1)
    {
        objectName = Name;
        sprite = Sprite;
        quantity = Quantity;
        stackable = Stackable;
        itemType = Type;
    }

    public string objectName = "name";
    public Sprite sprite;

    public int quantity;

    public bool stackable;
    public ItemType itemType;

    public enum ItemType
    {
        COIN,
        HEALTH,
        KEY
    }
    
}