using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public enum state { idle, look, attack};
    public state AIState = state.idle;
    public float distance;
    private GameObject player;

    public float speed = 3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distance = 2000;
    }
    // Update is called once per frame
    void Update()
    {
        if (distance > 18.0f)
        {
            AIState = state.idle;
        }

        else if (distance > 10f && distance <= 18.0f)
        {
            AIState = state.look;
        }

        else if (distance <= 10f)
        {
            AIState = state.attack;
        }

        if (AIState == state.idle)
        {
            Debug.Log(distance);
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
            float step = speed * Time.deltaTime;
            Vector3 relativePos = player.transform.position - transform.position;

            relativePos.y = 0;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;

            Vector3 newPos = Vector3.MoveTowards(transform.position, player.transform.position, step);

            newPos.y = transform.position.y;

            transform.position = newPos;
        }



    }
}
