using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    public Transform CollectableTransform;

    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;   
    public Sprite medkitSprite;
    public Sprite swordSprite;
    public Sprite coinSprite;

    void Awake()
    {
        Instance = this;
    }
}