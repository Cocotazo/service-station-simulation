using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsDetectors : MonoBehaviour
{
    
    void Start()
    {
        
    }
        
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vehicles vehicleColision = other.gameObject.transform.parent.GetComponentInChildren<Vehicles>();
        if (vehicleColision)
        {
            gameObject.transform.parent.gameObject.SendMessage("stayCollision", vehicleColision.speedToMilestone);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vehicles vehicleColision = other.gameObject.transform.parent.GetComponentInChildren<Vehicles>();
        if (vehicleColision)
        {
            gameObject.transform.parent.gameObject.SendMessage("stayCollision", vehicleColision.speedToMilestone);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vehicles vehicleColision = other.gameObject.transform.parent.GetComponentInChildren<Vehicles>();
        if (vehicleColision)
        {
            gameObject.transform.parent.gameObject.SendMessage("outCollision", vehicleColision.speedToMilestone);
        }
    }
}
