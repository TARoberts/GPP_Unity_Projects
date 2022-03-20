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

    private Transform startPos;

    [SerializeField] private Transform platform;
    [SerializeField] CharacterController player;
    [SerializeField] public ThirdPersonMovement moveScript;
    [SerializeField] GameObject splineCam, mainCam;

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
            splineCam.SetActive(true);
            mainCam.SetActive(false);

            if (Input.GetAxisRaw("Right Stick X") > 0.01f || Input.GetAxis("Right Stick X") < -0.01f)
            {
                Vector3 position = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z + (Input.GetAxisRaw("Right Stick X")));

                Debug.Log(position);
                this.transform.position = position;
                
            }

            else
            {
                this.transform.position = startPos.position;
            }

                
            platform.position = Vector3.MoveTowards(platform.position, splinePoints[currentSpline], step);

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
                mainCam.SetActive(true);
                splineCam.SetActive(false);
            }
        }



    }
}
