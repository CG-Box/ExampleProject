using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() 
    {
        id = System.Guid.NewGuid().ToString();
    }

    private SpriteRenderer visual;

    private bool collected = false;

    private void Awake() 
    {
        visual = this.GetComponent<SpriteRenderer>();
    }

    public void LoadData(GameData data) 
    {
        data.scene.coinsCollected.TryGetValue(id, out collected);
        if (collected) 
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data) 
    {
        if (data.scene.coinsCollected.ContainsKey(id))
        {
            data.scene.coinsCollected.Remove(id);
        }
        data.scene.coinsCollected.Add(id, collected);
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