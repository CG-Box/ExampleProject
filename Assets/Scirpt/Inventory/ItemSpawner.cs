using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Collectable
{
    public Item item;

    private void Awake() 
    {
        AlreadyCollectedFunction = () => {
            //Debug.Log($"AlreadyCollectedFunction: {fieldName} : {id}");
        };
    }

    private void Start()
    {
        if(!collected)
        {
            InventoryCollectable collectable = InventoryCollectable.SpawnItem(item, transform.position);
            collectable.BeforeDestroyFunction = () => {
                collected = true;
                Destroy(gameObject);
            };
        }
    }

}
