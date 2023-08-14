using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour, IDataPersistence
{
    private Inventory inventory;

    [SerializeField]
    private InventoryPanel inventoryPanel;

    void  Awake() {
        inventory = new Inventory(UseItemAction);   

        inventoryPanel.SetInventoryBehaviour(this);
        inventoryPanel.SetInventory(inventory);
    }

    private void Start() {
             
        /*InventoryCollectable.SpawnItem(
            new Item{type = ItemType.HealthPotion, amount = 1 }, new Vector3(8, 2.2f)
        );
        InventoryCollectable.SpawnItem(
            new Item{type = ItemType.Medkit, amount = 1 }, new Vector3(9, 2.2f)
        );
        InventoryCollectable.SpawnItem(
            new Item{type = ItemType.Sword, amount = 1 }, new Vector3(10, 2.2f)
        );*/
    }

    private void UseItemAction(Item item)
    {
        switch(item.type)
        {
            default:
            case ItemType.HealthPotion:
                inventory.RemoveItem(new Item {type = ItemType.HealthPotion, amount = 1});
                Debug.Log("Used: HealthPotion");
                break;
            case ItemType.ManaPotion:  
                inventory.RemoveItem(new Item {type = ItemType.ManaPotion, amount = 1});
                Debug.Log("Used: ManaPotion");
                break;
            case ItemType.Medkit:
                inventory.RemoveItem(item);
                Debug.Log("Used: Medkit");
                break;
            case ItemType.Sword:
                inventory.RemoveItem(item);
                Debug.Log("Used: Sword");
                break;
            case ItemType.Coin:
                inventory.RemoveItem(new Item {type = ItemType.Coin, amount = 1});
                Debug.Log("Used: Coin");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        InventoryCollectable collectable = collider.GetComponent<InventoryCollectable>();
        if(collectable != null)
        {
            Item collectedItem = collectable.GetItem();
            GameEvents.CollectEv.OnItemCollect?.Invoke(collectedItem);
            inventory.AddItem(collectedItem);
            collectable.DestroySelf();
        }
    }

    public void LoadData(GameData data)
    {
        inventory.LoadItemList(data.globals.itemList);
    }

    public void SaveData(GameData data)
    {
        data.globals.itemList = inventory.GetItemList();
    }

}
