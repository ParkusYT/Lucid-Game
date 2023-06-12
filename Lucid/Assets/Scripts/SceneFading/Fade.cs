using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image blackScreen;

    private void Start()
    {
        blackScreen.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
    {
        yield return new WaitForSeconds(1);
        blackScreen.CrossFadeAlpha(0.0f, 0.8f, false);
    }
}
