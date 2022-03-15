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

    [SerializeField] private Transform platform;
    [SerializeField] CharacterController player;
    [SerializeField] public ThirdPersonMovement moveScript;

    private void Start()
    {
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
            float step = 5 * Time.deltaTime;
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
            }
        }




    }

    public Vector3 WhereOnSpline(Vector3 pos)
    {
        
        return pos;
    }
}
