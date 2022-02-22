using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator animatorButton;
    public Animator animatorDoor;

    private bool doorOpen = false;

    private void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player")
        {
            animatorButton.Play("ButtonPush", 0, 0.0f);

            if (!doorOpen)
            {
                animatorDoor.Play("Door Slide Down", 0, 0.0f);
                doorOpen = true;
            }
            
        }
    }

}
