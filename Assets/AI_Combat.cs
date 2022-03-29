using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Combat : MonoBehaviour
{
    public int hp = 3;
    private bool hitStun = false;
    [SerializeField] Animator playerAnimator, myAnimator;
    private GameObject player;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Rigidbody body;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("ded");
            Destroy(this);
        }
        if (!hitStun)
        {
            attacked();
        }
    }

    IEnumerator attack()
    {
        hp--;
        yield return new WaitForSeconds(1.0f);
        hitStun = false;
    }


    void attacked()
    {
        Vector3 forward = player.transform.TransformDirection(Vector3.forward);
        Vector3 toOther = player.transform.position - transform.position;
        if (Vector3.Dot(forward, toOther) < -0.5f)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < 3.0f)
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                {
                    
                    particle.Play();
                    toOther.y = 0;
                    body.AddForce(toOther.normalized * -10.0f, ForceMode.Impulse);
                    hitStun = true;
                    StartCoroutine(attack());
                }
                
            }
        }
    }
}
