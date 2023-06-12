using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [Header("Level Name")]
    [SerializeField] private bool useName;
    [SerializeField] private string levelName;
        
    [Header("Level Index")]
    [SerializeField] private int levelIndex;

    [Header("Collider Settings")]
    [SerializeField] private bool colliderIsTrigger;

    [Header("Fading")]
    [SerializeField] private Image blackScreen;

    private void OnTriggerEnter(Collider collision)
    {
        if (colliderIsTrigger)
        {
            StartCoroutine(StartFade());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!colliderIsTrigger)
        {
            StartCoroutine(StartFade());
        }
    }

    IEnumerator StartFade()
    {
        blackScreen.CrossFadeAlpha(1.0f, 0.8f, false);
        yield return new WaitForSeconds(2);
        switch (useName)
        {
            case true:
                SceneManager.LoadScene(levelName);
                break;
            case false:
                SceneManager.LoadScene(levelIndex);
                break;
        }
    }
}
