using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSystemDetector : MonoBehaviour
{

    public float timeScale = 1;
    public float time = 1;
    public float timeInCollision = 0f;
    GeneratorVehicles generator;

    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("generatorOne").GetComponent<GeneratorVehicles>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        timeInCollision = time;
        if((time - timeInCollision) > 3)
        {            
            //nerator.occupySistem = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //generator.occupySistem = false;
    }
}
