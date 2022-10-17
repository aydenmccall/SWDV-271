using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    private GameObject InventoryPrefab;

    public Inventory Inventory;

    public UIManager(GameObject Inventory_Prefab)
    {
        InventoryPrefab = Inventory_Prefab;
    }

    private void InitializeInventory()
    {
        InventoryPrefab = Instantiate(InventoryPrefab);
        Inventory = InventoryPrefab.GetComponent<Inventory>();
        Inventory.Initialize();
    }

    public void InitiliazeUI()
    {
        InitializeInventory();
    }
}