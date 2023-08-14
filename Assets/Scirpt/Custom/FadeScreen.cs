using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    private Animator fadeAnimator;
    //private Transform fadeImage;

    private void Awake()
    {
        fadeAnimator = GetComponent<Animator>();
    }

    public void Fade()
    {
        fadeAnimator.SetTrigger("Fade");
    }
}
