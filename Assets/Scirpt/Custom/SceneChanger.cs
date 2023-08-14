using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class SceneChanger : MonoBehaviour
{
    [SerializeField]private string nextSceneName = "SampleScene";
    private bool canUse = false;
    private int disabledTimer = 1;
    private IEnumerator coroutineTimer;
    SpriteRenderer m_SpriteRenderer;
    Color activeColor;
    [SerializeField]Color disabledColor = Color.red;

    [field: SerializeField] 
    private GameEvent LoadLevelEvent;

    IEnumerator Countdown (int seconds) 
    {
        while (!canUse) {
            yield return new WaitForSeconds (seconds);
            canUse = true;
            m_SpriteRenderer.color = activeColor;
        }
    }

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        activeColor = m_SpriteRenderer.color;
        m_SpriteRenderer.color = disabledColor;
    }

    private void OnEnable() 
    {
        coroutineTimer = Countdown(disabledTimer);
        StartCoroutine(coroutineTimer);
    }
    private void OnDisable()
    {
        StopCoroutine(coroutineTimer);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(canUse && collider.tag == "Player")
        {
            LoadLevelEvent.Raise();
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
