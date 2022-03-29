using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Combat : MonoBehaviour
{
    
    public int startingHP;
    public int hp = 3;
    private bool hitStun = false;
    [SerializeField] Animator playerAnimator, myAnimator;
    private GameObject player, me;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Rigidbody body;


    private void Start()
    {
        hp = startingHP;
        me = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        if (hp == 2)
        {
            me.transform.localScale = new Vector3 (2f, 2f, 2f);
        }
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("ded");

            if (startingHP > 1)
            {
                hp = startingHP - 1;
                Instantiate(me, new Vector3(transform.position.x + 5, transform.position.y - 2, transform.position.z), Quaternion.identity);

                Instantiate(me, new Vector3(transform.position.x - 5, transform.position.y - 2, transform.position.z), Quaternion.identity);
            }

            Destroy(me);
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
