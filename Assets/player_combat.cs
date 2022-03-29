using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_combat : MonoBehaviour
{
    public int HP;
    [SerializeField] Animator playerAnimator;
    [SerializeField] AI_Combat aiCombat;
    public bool iFrame = false;

    private Transform enemy = null;

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            iFrame = true;
        }
        else
        {
            iFrame = false;
        }
        if (HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
