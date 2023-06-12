using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject text;
    [SerializeField] private Image blackScreen;

    bool alreadyFading = false;

    private void Awake()
    {
        blackScreen.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= 3)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(alreadyFading == false)
                    StartCoroutine(StartFade());
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    IEnumerator StartFade()
    {
        alreadyFading = true;
        blackScreen.CrossFadeAlpha(1.0f, 0.8f, false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Dream01");
    }
}
