using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryCollectable : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    public delegate void BeforeDestroyDelegate(); 
    public BeforeDestroyDelegate BeforeDestroyFunction;

    public static InventoryCollectable SpawnItem(Item item, Vector3 position)
    {
        Transform collectableTransform = Instantiate(ItemAssets.Instance.CollectableTransform, position, Quaternion.identity);

        InventoryCollectable collectable = collectableTransform.GetComponent<InventoryCollectable>();
        collectable.SetItem(item);

        return collectable;
    }

    public static InventoryCollectable DropItem(Item item, Vector3 dropPosition)
    {
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);
        var randomDir = new Vector3(x, y, 0f);
        randomDir = randomDir.normalized * 2f;

        InventoryCollectable collectable = SpawnItem(item, dropPosition + randomDir);
        collectable.GetComponent<Rigidbody2D>().AddForce(randomDir, ForceMode2D.Impulse);

        return collectable;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if(item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        BeforeDestroyFunction?.Invoke();
        Destroy(gameObject);
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }
}
