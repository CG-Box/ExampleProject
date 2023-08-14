using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class Key : MonoBehaviour
{
    [SerializeField]private string keyName = "Door_key";

    public string KeyName
    {
        get { return keyName; }
    }

   public Key(string keyName)
   {
      this.keyName = keyName;
   }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        KeyHolder keyHolder = col.GetComponent<KeyHolder>();
        if (keyHolder != null) 
        {
            Key thisKey = this;
            keyHolder.AddKey(thisKey);
            DestroyKey();
            keyHolder.PrintKeys();
        }
    }

    private void DestroyKey()
    {
        Destroy(gameObject);
    }
    public void HideKey()
    {
        gameObject.SetActive(false);
    }
    public void ShowKey()
    {
        gameObject.SetActive(true);
    }



    //Only for ScriptableObject keys
    [SerializeField]
    private KeySO keyScriptableObject; 


    [ContextMenu("Init Key from ScriptableObject")]
    public void InitKey()
    {
        if(!keyScriptableObject)
        {
            Debug.LogWarning("keyScriptableObject is not assigned");
            return;
        }
        keyName = keyScriptableObject.KeyName;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = keyScriptableObject.KeyColor;
    }
}
