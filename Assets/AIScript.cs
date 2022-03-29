using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public enum state { idle, look, chase, attack};
    public state AIState = state.idle;
    public float distance;
    private GameObject player;
    [SerializeField] player_combat combat;

    public float speed = 3;
    private bool canAttack = true;

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

        else if (distance > 15f && distance <= 18.0f)
        {
            AIState = state.look;
        }

        else if (distance > 3.0f && distance <= 15f)
        {
            AIState = state.chase;
        }

        else if (distance <= 3.0f)
        {
            AIState = state.attack;
        }

        if (AIState == state.idle)
        {
            
        }

        else if (AIState == state.look)
        {
            Vector3 relativePos = player.transform.position - transform.position;

            relativePos.y = 0;
            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }

        else if (AIState == state.chase)
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

        else if (AIState == state.attack)
        {
            if (canAttack)
            {
                canAttack = false;
                StartCoroutine(attack());
            }
            
        }



    }

    IEnumerator attack()
    {
        if (combat.iFrame == false)
        {
            combat.HP = combat.HP - 1;
        }
        yield return new WaitForSeconds(3.0f);
        canAttack = true;
    }
}
