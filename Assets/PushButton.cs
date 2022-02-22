using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player")
        {
            
            animator.Play("ButtonPush", 0, 0.0f);
        }
    }

}
