using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public Transform playerTransform;

    Cinemachine.CinemachineVirtualCamera c_VirtualCamera;

    private void Start()
    {
        c_VirtualCamera = this.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit target;

        if (Input.GetButtonDown("LockOn"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out target, Mathf.Infinity))
            {
                c_VirtualCamera.LookAt = target.transform;
                Debug.Log("hit");
            }
        }

        if (Input.GetButtonUp("LockOn"))
        {
           // c_VirtualCamera.LookAt = playerTransform;
        }

    }
}
