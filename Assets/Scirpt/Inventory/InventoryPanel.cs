using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{

    private Inventory inventory;

    [SerializeField]private Transform itemsContainer;
    [SerializeField]private Transform itemTemplate;

    [SerializeField]private float slotSize = 50f;
    [SerializeField]private int amountInLine = 7;

    private InventoryBehaviour inventoryBehaviour;

    public void SetInventoryBehaviour(InventoryBehaviour inventoryBehaviour)
    {
        this.inventoryBehaviour = inventoryBehaviour;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += InventoryPanel_OnListChanged;

        Refresh();
    }

    private void InventoryPanel_OnListChanged(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        foreach(Transform child in itemsContainer)
        {
            if(child == itemTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemTemplate, itemsContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * slotSize, y * slotSize);

            Image slotImage = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            slotImage.sprite = item.GetSprite();

            TextMeshProUGUI slotText = itemSlotRectTransform.Find("ItemCount").GetComponent<TextMeshProUGUI>();

            ClickableObject clickObj = itemSlotRectTransform.GetComponent<ClickableObject>();
            clickObj.LeftClickFunction = () => {
                //Debug.Log("Left click item: "+item.type.ToString());
            };
            clickObj.MiddleClickFunction = () => {
                Drop(item);
            };
            clickObj.RightClickFunction = () => {
                Use(item);
            };
 
            if(item.amount > 1)
            {
                slotText.SetText(item.amount.ToString());
            }
            else
            {
                slotText.SetText("");
            }
            
            x++;
            if(x > amountInLine)
            {
                x = 0;
                y++;
            }
        }
    }

    public void Drop(Item item)
    {
        Item duplicateItem = new Item {type = item.type, amount = item.amount};
        inventory.RemoveItem(item);
        InventoryCollectable.DropItem(duplicateItem, inventoryBehaviour.gameObject.transform.position);
    }
    public void Use(Item item)
    {
        inventory.UseItem(item);
    }
 
}
