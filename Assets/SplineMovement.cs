using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMovement : MonoBehaviour
{
    private Vector3[] splinePoints;
    private int noSplines;
    private int currentSpline = 0; 

    public bool debugSpline = true;
    public bool activeSpline;
    public float speed = 5;
    private Vector3 direction;

    private Transform startPos;

    [SerializeField] private Transform platform;
    [SerializeField] CharacterController player;
    [SerializeField] Animator playerAnimator;
    [SerializeField] public ThirdPersonMovement moveScript;
    [SerializeField] GameObject splineCam_1, splineCam_2, mainCam;

    private void Start()
    {
        startPos = this.transform;
        activeSpline = false;
        noSplines = transform.childCount;
        splinePoints = new Vector3[noSplines];


        for (int i = 0; i < noSplines; i++)
        {
            splinePoints[i] = transform.GetChild(i).position;
        }
    }

    private void Update()
    {
        for (int i = 0; i < noSplines; i++)
        {
            splinePoints[i] = transform.GetChild(i).position;
        }

        camController();

        if (noSplines > 1 && debugSpline)
        {
            for (int i = 0; i < noSplines; i++)
            {
                if (i+1 < noSplines)
                {
                    Debug.DrawLine(splinePoints[i], splinePoints[i + 1], Color.red);
                }
                
            }
        }

        if (activeSpline)
        {
            
            float step = speed * Time.deltaTime;
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical);
            float magnitude = direction.magnitude;
            direction.Normalize();


            if (direction.magnitude >= 0.1f)
            {
                platform.position = Vector3.MoveTowards(platform.position, splinePoints[currentSpline], step);
                playerAnimator.SetBool("Moving", true);
            }
            else
            {
                playerAnimator.SetBool("Moving", false);
            }

                /*platform.position = Vector3.MoveTowards(platform.position, splinePoints[currentSpline], step);*/

            if (Vector3.Distance(platform.position, splinePoints[currentSpline]) < 0.1f)
            {
                if (currentSpline < noSplines)
                {
                    currentSpline++;
                }

            }
            if (currentSpline == noSplines)
            {
                player.transform.parent = null;
                moveScript.active = true;
                activeSpline = false;
                player.enabled = true;
/*                mainCam.SetActive(true);
                splineCam_1.SetActive(false);*/
            }
        }



    }

    void camController()
    {
        if (activeSpline)
        {
            if (currentSpline == 2 || currentSpline == 3)
            {
                mainCam.SetActive(false);
                splineCam_1.SetActive(false);
                splineCam_2.SetActive(true);
            }
            else
            {
                mainCam.SetActive(false);
                splineCam_1.SetActive(true);
                splineCam_2.SetActive(false);
            }
        }
        else
        {
            mainCam.SetActive(true);
            splineCam_1.SetActive(false);
            splineCam_2.SetActive(false);
        }
    }
}
