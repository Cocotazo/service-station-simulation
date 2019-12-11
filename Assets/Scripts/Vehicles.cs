using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Events;
using System.Threading;

public class Vehicles : MonoBehaviour
{
    
    public GameObject car;
    public float[] speedsMovements;
    public bool collisionDetected;
    public float speedToMilestone;
    public float timeScale = 1;
    public float time = 1;
    public float arrivedTime = 0;
    public float diference;
    public bool timeLabel;
    public int subWay = 0;
    public float timeStimatedInService;
    public float initialSpeed;
    public GameObject[] milestoneMovements = new GameObject[9];
    public int nextMilestone = 0;

    private GameObject alternativeRouteMilestoneOne;
    private Transform thisTransform;
    private Rigidbody carRigidBody;    
    private int rideCode;
    
    private string colisionState = "outColision";
    

    public bool fuelModuleA;
    public bool fuelModuleB;
    public bool fuelModuleC;
    public bool fuelModuleD;
    public bool fuelModuleE;
    public bool fuelModuleF;


    public bool canGotoNextMilestone { get; set; }

    void Start()
    {
        timeStimatedInService = stimatedTimeInFuelModule();
        initialSpeed = speedsMovements[0];
        thisTransform = transform;
        carRigidBody = GetComponentInParent<Rigidbody>();
        canGotoNextMilestone = true;

        if (car.transform.position == GameObject.FindWithTag("generatorOne").transform.position)
        {
            rideCode = 1;
            milestoneMovements[0] = GameObject.FindWithTag("milestoneOne");
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
        time += Time.deltaTime * timeScale;
        
        rotationVehicles();

        fuelModuleAOccupy();
        fuelModuleBOccupy();
        fuelModuleCOccupy();
        fuelModuleDOccupy();
        fuelModuleEOccupy();
        fuelModuleFOccupy();
        try
        {
            switch (colisionState)
            {
                case "enterColision":
                    speedToMilestone = 0;
                    break;
                case "stayInColision":
                    collisionDetected = false;
                    break;
                case "outColision":                    
                    speedToMilestone = speedsMovements[nextMilestone];
                    break;
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

                nextMilestone++;
                calculateWay(nextMilestone);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void calculateWay(int nextMile)
    {        
        if (nextMile <= 3)
        {            
            if (car.gameObject.tag.Equals("Bus"))
            {
                calculateBusWay(nextMile);
                subWay = 0;
            }
            else 
            {
                calculateCarWay(nextMile);                
            }
        }
        else if(nextMile == 10)
        {
            Destroy(car);
        }
    }

    private void rotationVehicles()
    {
        switch (subWay)
        {
            case 0:
                switch (nextMilestone)
                {
                    case 1:
                        if (car.tag.Equals("Bus"))
                        {
                            transform.Rotate(Vector3.up * Time.deltaTime, 1f, Space.World);
                        }
                        else
                        {
                            transform.Rotate(Vector3.up * Time.deltaTime, 0.9f, Space.World);
                        }
                        break;
                    case 3:
                        transform.Rotate(Vector3.up * - Time.deltaTime, 0.7f, Space.World);
                        break;
                    case 5:
                        inFuelModule();
                        break;
                    case 6:
                        transform.Rotate(Vector3.up * -Time.deltaTime, 0.3f, Space.World);
                        break;
                    case 8:
                        transform.Rotate(Vector3.up * Time.deltaTime, 1.1f, Space.World);
                        break;
                }
                break;
            case 1:
                switch (nextMilestone)
                {
                    case 3:
                        transform.Rotate(Vector3.up * -Time.deltaTime, 0.55f, Space.World);
                        break;
                    case 5:
                        inFuelModule();
                        break;
                    case 6:
                        transform.Rotate(Vector3.up * - Time.deltaTime, 0.4f, Space.World);
                        break;
                    case 8:
                        transform.Rotate(Vector3.up * Time.deltaTime, 0.6f, Space.World);
                        break;
                }                
                break;
            case 2:
                switch (nextMilestone)
                {
                    case 4:
                        transform.Rotate(Vector3.up * -Time.deltaTime, 0.9f, Space.World);
                        break;
                    case 6:
                        inFuelModule();
                        break;
                    case 7:
                        transform.Rotate(Vector3.up * - Time.deltaTime, 0.4f, Space.World);
                        break;
                    case 9:
                        transform.Rotate(Vector3.up * Time.deltaTime, 0.6f, Space.World);
                        break;
                }
                break;
            case 3:
                switch (nextMilestone)
                {
                    case 4:
                        transform.Rotate(Vector3.up * -Time.deltaTime, 0.9f, Space.World);
                        break;
                    case 6:
                        inFuelModule();
                        break;
                    case 7:
                        transform.Rotate(Vector3.up * - Time.deltaTime, 0.4f, Space.World);
                        break;
                    case 9:
                        transform.Rotate(Vector3.up * Time.deltaTime, 0.6f, Space.World);
                        break;
                }
                break;
        }
    }

    private void calculateCarWay(int nextMile)
    {
        switch (nextMile)
        {
            case 1:                                
                milestoneMovements[1] = GameObject.FindWithTag("milestoneOneA");
                break;
            case 2:
                milestoneMovements[2] = GameObject.FindWithTag("milestoneTwoA");
                break;
            case 3:
                if (verifiyFuelsModules())
                {
                    if (!fuelModuleB)
                    {
                        subWay = 1;
                        firstCarsSubWay();                        
                    }
                    else if(!fuelModuleC)
                    {
                        subWay = 2;
                        secondCarsSubWay();
                    }
                    else if(!fuelModuleD)
                    {
                        subWay = 3;
                        thirdCarsSubWay();
                    }
                    else
                    {
                        nextMilestone--;
                    }
                }
                else
                {
                    nextMilestone--;
                }
                break;
        }
    }    

    private void firstCarsSubWay()
    {
        //ROTACION
        milestoneMovements[3] = GameObject.FindWithTag("milestoneTwoA1");
        milestoneMovements[4] = GameObject.FindWithTag("milestoneFinalB");
        milestoneMovements[5] = GameObject.FindWithTag("milestoneFinalB1");
        //ROTACION
        milestoneMovements[6] = GameObject.FindWithTag("milestoneFinalB2");
        milestoneMovements[7] = GameObject.FindWithTag("milestoneFinal");
        //ROTACION
        milestoneMovements[8] = GameObject.FindWithTag("milestoneFinal1");
        milestoneMovements[9] = GameObject.FindWithTag("milestoneFinal2");
    }
    private void secondCarsSubWay()
    {
        milestoneMovements[3] = GameObject.FindWithTag("milestoneTwoB");
        //ROTACION
        milestoneMovements[4] = GameObject.FindWithTag("milestoneTwoB1");        
        milestoneMovements[5] = GameObject.FindWithTag("milestoneFinalC");
        milestoneMovements[6] = GameObject.FindWithTag("milestoneFinalC1");
        //ROTACION
        milestoneMovements[7] = GameObject.FindWithTag("milestoneFinalC2");
        milestoneMovements[8] = GameObject.FindWithTag("milestoneFinal");
        //ROTACION
        milestoneMovements[9] = GameObject.FindWithTag("milestoneFinal1");
        milestoneMovements[10] = GameObject.FindWithTag("milestoneFinal2");
    }
    private void thirdCarsSubWay()
    {
        milestoneMovements[3] = GameObject.FindWithTag("milestoneTwoB");
        //ROTACION
        milestoneMovements[4] = GameObject.FindWithTag("milestoneTwoB2");
        milestoneMovements[5] = GameObject.FindWithTag("milestoneFinalD");
        milestoneMovements[6] = GameObject.FindWithTag("milestoneFinalD1");
        //ROTACION
        milestoneMovements[7] = GameObject.FindWithTag("milestoneFinalD2");
        milestoneMovements[8] = GameObject.FindWithTag("milestoneFinal");
        //ROTACION
        milestoneMovements[9] = GameObject.FindWithTag("milestoneFinal1");
        milestoneMovements[10] = GameObject.FindWithTag("milestoneFinal2");
    }

    private void calculateBusWay(int nextMile)
    {
        switch (nextMile)
        {
            case 1:
                milestoneMovements[1] = GameObject.FindWithTag("milestoneOneA");
                break;
            case 2:
                milestoneMovements[2] = GameObject.FindWithTag("milestoneTwoC");
                break;
            case 3:
                if (!fuelModuleE)
                {
                    milestoneMovements[3] = GameObject.FindWithTag("milestoneTwoC1");
                    milestoneMovements[4] = GameObject.FindWithTag("milestoneFinalE");
                    milestoneMovements[5] = GameObject.FindWithTag("milestoneFinalE1");
                    //ROTACION
                    milestoneMovements[6] = GameObject.FindWithTag("milestoneFinalE2");
                    milestoneMovements[7] = GameObject.FindWithTag("milestoneFinal");
                    milestoneMovements[8] = GameObject.FindWithTag("milestoneFinal1");
                    milestoneMovements[9] = GameObject.FindWithTag("milestoneFinal2");
                }
                else if (!fuelModuleF)
                {
                    milestoneMovements[3] = GameObject.FindWithTag("milestoneTwoC2");
                    milestoneMovements[4] = GameObject.FindWithTag("milestoneFinalF");
                    milestoneMovements[5] = GameObject.FindWithTag("milestoneFinalF1");
                    //ROTACION
                    milestoneMovements[6] = GameObject.FindWithTag("milestoneFinalF2");
                    milestoneMovements[7] = GameObject.FindWithTag("milestoneFinal");
                    milestoneMovements[8] = GameObject.FindWithTag("milestoneFinal1");
                    milestoneMovements[9] = GameObject.FindWithTag("milestoneFinal2");
                }
                else
                {
                    nextMilestone--;
                }
                break;
            case 10:
                Destroy(car);
                break;
        }
    }

    private bool verifiyFuelsModules()
    {
        if (!fuelModuleB || !fuelModuleC || !fuelModuleD || !fuelModuleE || !fuelModuleF)
        {
            return true;
        }
        return false;
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
    
    private void inFuelModule()
    {
        if (!timeLabel)
        {
            arrivedTime = time;
            timeLabel = true;
        }
        diference = time - arrivedTime;
        
        if (diference < timeStimatedInService)
        {
            inCollision();
        }
        else
        {
            outCollision();
        }
    }

    private float stimatedTimeInFuelModule()
    {
        if (car.tag.Equals("Bus"))
            return 240f;

        return Random.Range(120, 180);
    }
    
    private void inCollision()
    {
        collisionDetected = true;
        colisionState = "enterColision";        
    }
    
    private void stayCollision(float speed)
    {
        colisionState = "stayInColision";
        speedToMilestone = speed;
    }

    private void outCollision()
    {
        collisionDetected = false;
        colisionState = "outColision";
    }

    public void fuelModuleAOccupy()
    {
        //FuelModule fuelModule = GameObject.FindWithTag("fuelModuleA").gameObject.transform.GetComponentInChildren<FuelModule>();
        //fuelModuleA = fuelModule.fuelModuleState;
    }

    public void fuelModuleBOccupy()
    {
        FuelModule fuelModule = GameObject.FindWithTag("fuelModuleB").gameObject.transform.GetComponentInChildren<FuelModule>();
        fuelModuleB = fuelModule.fuelModuleState;
    }

    public void fuelModuleCOccupy()
    {
        FuelModule fuelModule = GameObject.FindWithTag("fuelModuleC").gameObject.transform.GetComponentInChildren<FuelModule>();
        fuelModuleC = fuelModule.fuelModuleState;
    }

    public void fuelModuleDOccupy()
    {
        FuelModule fuelModule = GameObject.FindWithTag("fuelModuleD").gameObject.transform.GetComponentInChildren<FuelModule>();
        fuelModuleD = fuelModule.fuelModuleState;
    }

    public void fuelModuleEOccupy()
    {
        FuelModule fuelModule = GameObject.FindWithTag("fuelModuleE").gameObject.transform.GetComponentInChildren<FuelModule>();
        fuelModuleE = fuelModule.fuelModuleState;
    }

    public void fuelModuleFOccupy()
    {
        FuelModule fuelModule = GameObject.FindWithTag("fuelModuleF").gameObject.transform.GetComponentInChildren<FuelModule>();
        fuelModuleF = fuelModule.fuelModuleState;
    }

}
