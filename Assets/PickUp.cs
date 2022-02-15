using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject player;
    //when player walks in

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && tag == "SpeedBoost")
        {
            ParticleSystem particle = GetComponentInChildren<ParticleSystem>();
            particle.Play();
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        ThirdPersonMovement movement = player.GetComponent<ThirdPersonMovement>();
        movement.speed = 10;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        movement.speed = 6;
        gameObject.SetActive(false);
        yield return null;
    }

}
