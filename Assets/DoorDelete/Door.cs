using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    const string openTriggerName = "Open";

    [SerializeField]private string neededkey = "Default_key";

    private bool isOpen = false; 
    public bool IsOpen
    {
        get { return isOpen; }
    }

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        isOpen = true;
        animator.SetBool(openTriggerName, isOpen);
    }

    public void CloseDoor()
    {
        isOpen = false;
        animator.SetBool(openTriggerName, isOpen);
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(isOpen)return;

        KeyHolder keyHolder = col.GetComponent<KeyHolder>();
        if (keyHolder != null) 
        {
            bool hasAllKeys = false;
            hasAllKeys = keyHolder.ContainsKey(neededkey);
            Debug.Log("hasAllKeys : " + hasAllKeys);
            if(hasAllKeys)
            {
                OpenDoor();
                keyHolder.PrintKeys();
                //keyHolder.RemoveKey(neededkey);
                //keyHolder.PrintKeys();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        if(!isOpen)return;

        KeyHolder keyHolder = col.GetComponent<KeyHolder>();
        if (keyHolder != null) 
        {
            CloseDoor();
        }
    }


        //Only for ScriptableObject keys
    [SerializeField]private KeySO neededkeySO; 


    [ContextMenu("Init Key from ScriptableObject")]
    private void InitKey()
    {
        neededkey = neededkeySO.KeyName;

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = neededkeySO.KeyColor;
    }    
}
