using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class Vehicles : MonoBehaviour
{


    public GameObject[] milestoneMovements = new GameObject[2];    
    public GameObject car;
    public float[] speedsMovements;
    public bool collisionDetected;

    private GameObject alternativeRouteMilestoneOne;
    private Transform thisTransform;
    private Rigidbody carRigidBody;
    private int nextMilestone = 0;
    private bool toBomb;
    private int rideCode;


    

    float speedToMilestone = 0;

    public bool canGotoNextMilestone { get; set; }

    void Start()
    {        
        thisTransform = transform;
        carRigidBody = GetComponentInParent<Rigidbody>();
        canGotoNextMilestone = true;
        if (car.transform.position == GameObject.FindWithTag("generatorOne").transform.position)
        {
            rideCode = 1;
            milestoneMovements[0] = GameObject.FindWithTag("milestoneOne");
            milestoneMovements[1] = GameObject.FindWithTag("milestoneTwo");
        }
        else if(car.transform.position == GameObject.FindWithTag("generatorTwo").transform.position)
        {
            rideCode = 2;
            milestoneMovements[0] = GameObject.FindWithTag("milestoneThree");
        }
        else if (car.transform.position == GameObject.FindWithTag("generatorThree").transform.position)
        {
            rideCode = 3;
            milestoneMovements[0] = GameObject.FindWithTag("milestoneFour");
        }
        else 
        {
            rideCode = 4;
            milestoneMovements[0] = GameObject.FindWithTag("milestoneFive");
        }
    }

    // Update is called once per frame
    void Update()
    {                
        try
        {
            if (!collisionDetected)
            {
                speedToMilestone = speedsMovements[nextMilestone];
            }
            else
            {
                speedToMilestone = 0;
            }
                
        }
        catch
        {
            speedToMilestone = 0;
        }
        if (!collisionDetected)
        {
            switch (rideCode)
            {
                case 1:
                    firstRide(speedToMilestone);
                    break;
                case 2:
                    secondRide(speedToMilestone);
                    break;
                case 3:
                    thirdRide(speedToMilestone);
                    break;
                case 4:
                    fourRide(speedToMilestone);
                    break;
            }
        }
            
    }

    private void firstRide(float speedToMilestone)
    {
        try
        {
            if (goToMilestone(milestoneMovements[nextMilestone].transform.position, speedToMilestone))
            {
                canGotoNextMilestone = false;
                bool paternFound = false;
                MonoBehaviour[] milestoneScripts = milestoneMovements[nextMilestone].GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in milestoneScripts)
                {
                    if (script.GetType().Name.Contains("Patron"))
                    {
                        paternFound = true;
                        script.enabled = true;
                    }
                }

                if (!paternFound)
                {
                    canGotoNextMilestone = true;
                }

                if (nextMilestone != milestoneMovements.Length - 1)
                {                    
                    //float y = 0;
                    nextMilestone++;
                    //y += Time.deltaTime * 8;
                    thisTransform.position = new Vector3(0.1f, 0, 5f);
                    thisTransform.rotation = Quaternion.Euler(0, 349.82f, 0);
                }
                else
                {
                    //nextMilestone = 2;                        
                    Destroy(car);
                }

            }
        }
        catch
        {
            nextMilestone++;
        }
    }

    private void secondRide(float speedToMilestone)
    {
        if (canGotoNextMilestone)
        {            
            if (canGotoNextMilestone)
            {
                try
                {
                    if (goToMilestone(milestoneMovements[nextMilestone].transform.position, speedToMilestone))
                    {
                        canGotoNextMilestone = false;
                        bool paternFound = false;
                        MonoBehaviour[] milestoneScripts = milestoneMovements[nextMilestone].GetComponents<MonoBehaviour>();
                        foreach (MonoBehaviour script in milestoneScripts)
                        {
                            if (script.GetType().Name.Contains("Patron"))
                            {
                                paternFound = true;
                                script.enabled = true;
                            }
                        }

                        if (!paternFound)
                        {
                            canGotoNextMilestone = true;
                        }

                        if (nextMilestone != milestoneMovements.Length - 1)
                        {
                            nextMilestone++;
                            Destroy(car);
                        }
                    }
                }
                catch
                {
                    nextMilestone++;
                }
            }
        }
    }

    private void thirdRide(float speedToMilestone)
    {
        if (canGotoNextMilestone)
        {
            if (canGotoNextMilestone)
            {
                try
                {
                    if (goToMilestone(milestoneMovements[nextMilestone].transform.position, speedToMilestone))
                    {
                        canGotoNextMilestone = false;
                        bool paternFound = false;
                        MonoBehaviour[] milestoneScripts = milestoneMovements[nextMilestone].GetComponents<MonoBehaviour>();
                        foreach (MonoBehaviour script in milestoneScripts)
                        {
                            if (script.GetType().Name.Contains("Patron"))
                            {
                                paternFound = true;
                                script.enabled = true;
                            }
                        }

                        if (!paternFound)
                        {
                            canGotoNextMilestone = true;
                        }

                        if (nextMilestone != milestoneMovements.Length - 1)
                        {
                            nextMilestone++;
                            Destroy(car);
                        }
                    }
                }
                catch
                {
                    nextMilestone++;
                }
            }
        }
    }

    private void fourRide(float speedToMilestone)
    {
        if (canGotoNextMilestone)
        {
            if (canGotoNextMilestone)
            {
                try
                {
                    if (goToMilestone(milestoneMovements[nextMilestone].transform.position, speedToMilestone))
                    {
                        canGotoNextMilestone = false;
                        bool paternFound = false;
                        MonoBehaviour[] milestoneScripts = milestoneMovements[nextMilestone].GetComponents<MonoBehaviour>();
                        foreach (MonoBehaviour script in milestoneScripts)
                        {
                            if (script.GetType().Name.Contains("Patron"))
                            {
                                paternFound = true;
                                script.enabled = true;
                            }
                        }

                        if (!paternFound)
                        {
                            canGotoNextMilestone = true;
                        }

                        if (nextMilestone != milestoneMovements.Length - 1)
                        {
                            nextMilestone++;
                            Destroy(car);
                        }
                    }
                }
                catch
                {
                    nextMilestone++;
                }
            }
        }
    }

    private bool goToMilestone(Vector3 milestonePosition, float speed)
    {
        Vector3 distanceBeetwenObjects = milestonePosition - thisTransform.position;
        distanceBeetwenObjects = new Vector3(distanceBeetwenObjects.x, 0, distanceBeetwenObjects.z);

        if(Math.Abs(distanceBeetwenObjects.x) > 0.2f ||
            Math.Abs(distanceBeetwenObjects.y) > 0.2f ||
            Math.Abs(distanceBeetwenObjects.z) > 0.2f) 
        {
            distanceBeetwenObjects.Normalize();
            distanceBeetwenObjects *= speed;
            distanceBeetwenObjects = new Vector3(
                distanceBeetwenObjects.x,
                distanceBeetwenObjects.y,
                distanceBeetwenObjects.z);

            thisTransform.Translate(distanceBeetwenObjects * Time.deltaTime, Space.World);

            return false;
        }
        else
        {
            return true;
        }

    }

    private void inCollision()
    {
        collisionDetected = true;
    }

    private void outCollision()
    {
        collisionDetected = false;
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car") || collision.gameObject.name.Contains("Bus"))
        {
            collisionDetected = true;
        }        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car") || collision.gameObject.name.Contains("Bus"))
        {
            collisionDetected = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car") || collision.gameObject.name.Contains("Bus"))
        {
            collisionDetected = false;
        }
    }*/
}
