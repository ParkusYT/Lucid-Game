using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource button;

    bool alreadyPressed;

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 3)
        {
            text.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (alreadyPressed == false)
                {
                    player.gravity = 1f;
                    player.velocity.y = 0f;
                    button.Play();
                    StartCoroutine(WaitForReturn());
                }
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    IEnumerator WaitForReturn()
    {
        alreadyPressed = true;
        yield return new WaitForSeconds(8);
        player.gravity = -2f;
        yield return new WaitForSeconds(12);
        player.gravity = -9.87f;
        alreadyPressed = false;
    }
}
