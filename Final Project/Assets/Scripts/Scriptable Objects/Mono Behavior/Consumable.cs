using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : ScriptableObject
{
    public Sprite sprite;
    public string Objectname;
    public bool stackable;
    public int qty = 1;
    //public ItemType Type;
    public Item Item;

    protected void Initialize()
    {
        Item = new Item(Objectname, sprite, stackable, qty);
    }

    private void Start()
    {
        Initialize();
    }
    
}
