using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator animatorButton;
    public Animator animatorDoor;
    public Animator playerAnimator;
    public GameObject player;

    private bool doorOpen = false;

    private void Start()
    {
        //ButtonPush push = player.GetComponent<ButtonPush>();
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player")
        {
           CSFunction();
        }
    }

    void CSFunction()
    {
        ThirdPersonMovement movement = player.GetComponent<ThirdPersonMovement>();
        movement.speed = 0;
        movement.inCS = true;
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        ThirdPersonMovement movement = player.GetComponent<ThirdPersonMovement>();
        movement.CSCam1.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        
        playerAnimator.Play("Button", 0, 0.0f);
        yield return new WaitForSeconds(0.5f);
        animatorButton.Play("ButtonPush", 0, 0.0f);

        movement.inCS = false;

        if (!doorOpen)
        {
            movement.CSCam2.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            animatorDoor.Play("Door Slide Down", 0, 0.0f);
            doorOpen = true;
            yield return new WaitForSeconds(2.5f);
          
        }

        movement.CSCam1.gameObject.SetActive(false);
        movement.CSCam2.gameObject.SetActive(false);

        yield return null;
        
    }

}
