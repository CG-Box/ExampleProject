using System;
using UnityEditor;

using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Detect collision by Tag-Name or Script-Name")]
    private bool useTag = true;
    public bool UseTag {get { return useTag; }}

    [SerializeField]
    [Tooltip("What Tag-Name will invoke collision")]
    private string _colliderTag;

    [SerializeField]
    [Tooltip("What Script-Name will invoke collision")]
    private string _colliderScript;


    [SerializeField]
    private UnityEvent _onTriggerEnter;

    [SerializeField]
    private UnityEvent _onTriggerExit;

    private delegate void DelegateOnEnter(Collider2D other);
    private delegate void DelegateOnExit(Collider2D other);
    private DelegateOnEnter _onEnter;
    private DelegateOnExit _onExit;

    void OnEnable()
    {
        if(useTag)
        {
            _onEnter += CheckTagEnter;
            _onExit += CheckTagExit;  
        }
        else //using script name
        {
            _onEnter += CheckScriptEnter;
            _onExit += CheckScriptExit;
        }
    }
    void OnDisable()
    {
        if(useTag)
        {
            _onEnter -= CheckTagEnter;
            _onExit -= CheckTagExit; 
        }
        else //using script name
        {
            _onEnter -= CheckScriptEnter;
            _onExit -= CheckScriptExit; 
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        _onEnter(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _onExit(other);
    }


    void CheckScriptEnter(Collider2D other)
    {
        if(other.gameObject.GetComponent(_colliderScript))
        {
            _onTriggerEnter?.Invoke();
        }
    }
    void CheckTagEnter(Collider2D other)
    {
        if (other.tag == _colliderTag)
        {
            _onTriggerEnter?.Invoke();
        }
    }
    void CheckScriptExit(Collider2D other)
    {
        if(other.gameObject.GetComponent(_colliderScript))
        {
            _onTriggerExit?.Invoke();
        }
    }
    void CheckTagExit(Collider2D other)
    {
        if (other.tag == _colliderTag)
        {
            _onTriggerExit?.Invoke();
        }
    }

    public void PrintTarget()
    {
        Debug.Log("Collider Tag: " + _colliderTag);
        Debug.Log("Collider Script: " + _colliderScript);
    }
}