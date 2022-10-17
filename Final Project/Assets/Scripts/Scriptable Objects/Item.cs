using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item
{
    public Item(string Name, Sprite Sprite, bool Stackable = false, int Quantity = 1)
    {
        objectName = Name;
        sprite = Sprite;
        quantity = Quantity;
        stackable = Stackable;
    }

    public string objectName = "name";
    public Sprite sprite;

    public int quantity;

    public bool stackable;

    //public enum ItemType
    //{
    //    COIN,
    //    HEALTH
    //}
}