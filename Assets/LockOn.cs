using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField] Cinemachine.CinemachineFreeLook c_VirtualCamera;
    
    Transform targetTransform;
    [SerializeField] GameObject lockedoneffect;

    bool lockedon = false;


    void Update()
    {
        RaycastHit target;
        if (Input.GetButtonDown("LockOn"))
        {
            if (!lockedon)
            {
                if (Physics.Raycast(transform.position, transform.forward, out target, Mathf.Infinity))
                {
                    if (target.transform.tag == "Enemy")
                    {
                        targetTransform = target.transform;
                        c_VirtualCamera.m_LookAt = targetTransform;
                        GameObject targetting = Instantiate(lockedoneffect, targetTransform);
                        targetting.transform.position = targetTransform.position;
                        lockedon = true;

                        Debug.Log("hit");
                    }
                    

                }
            }
            else if (lockedon)
            {
                c_VirtualCamera.LookAt = playerTransform;
                
                lockedon = false;
            }

        }

        else if (Input.GetButtonUp("LockOn"))
        {
            
            
        }

    }
}
