using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelModule : MonoBehaviour
{
    public string fuelModuleSelected;
    public bool fuelModuleState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string fuelModule = gameObject.tag;
        fuelModuleSelected = fuelModule;
        fuelModuleState = true;
    }

    private void OnTriggerStay(Collider other)
    {
        string fuelModule = gameObject.tag;
        fuelModuleSelected = fuelModule;
        fuelModuleState = true;
    }

    private void OnTriggerExit(Collider other)
    {
        string fuelModule = gameObject.tag;
        fuelModuleState = false;
    }
}
