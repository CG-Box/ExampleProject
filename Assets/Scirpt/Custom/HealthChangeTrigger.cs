using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeTrigger : MonoBehaviour
{
    [field: SerializeField] 
    private FloatValue Health;
    
    [field: SerializeField] 
    private GameEvent HealthChangeEvent;

    [field: SerializeField]
    private float Delta = -10f; 

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            Health.Value += Delta;
            HealthChangeEvent.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            //Health.Value += Delta;
            //Debug.Log(Health.name);
        }
    }
}
