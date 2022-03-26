using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public enum state { idle, look, attack};
    public state AIState = state.idle;
    public float distance;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (distance > 5.0f)
        {
            AIState = state.idle;
        }

        else if (distance > 2.50f && distance <= 5.0f)
        {
            AIState = state.look;
        }

        else if (distance <= 2.5f)
        {
            AIState = state.attack;
        }

        if (AIState == state.idle)
        {
            //do nothing
        }

        else if (AIState == state.look)
        {
            Vector3 relativePos = player.transform.position - transform.position;

            relativePos.y = 0;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }

        else if (AIState == state.attack)
        {
            Vector3 relativePos = player.transform.position - transform.position;

            relativePos.y = 0;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;


        }



    }
}
