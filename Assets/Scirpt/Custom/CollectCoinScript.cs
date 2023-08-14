using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinScript : Collectable
{
    private SpriteRenderer visual;
    private void Awake() 
    {
        visual = this.GetComponent<SpriteRenderer>();
        AlreadyCollectedFunction = () => {
             visual.gameObject.SetActive(false);
        };
    }

    private void OnTriggerEnter2D() 
    {
        if (!collected) 
        {
            GetCoin();
        }
    }

    private void GetCoin() 
    {
        collected = true;
        visual.gameObject.SetActive(false);
    }
}
