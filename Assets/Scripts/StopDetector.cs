using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDetector : MonoBehaviour
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
            gameObject.transform.parent.gameObject.SendMessage("inCollision");
            Debug.Log("Stop");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Vehicles vehicleColision = other.gameObject.transform.parent.GetComponentInChildren<Vehicles>();
        if (vehicleColision)
        {
            gameObject.transform.parent.gameObject.SendMessage("inCollision");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.parent.gameObject.SendMessage("outCollision");
        Debug.Log("Go");
    }
}
