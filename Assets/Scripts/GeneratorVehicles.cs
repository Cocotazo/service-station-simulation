using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorVehicles : MonoBehaviour {

    public GameObject[] cars;    
    private float minTimeBetweenStones = 4f, maxTimeBetweenStones = 7f;
    
    void Start(){
        StartCoroutine(creatorCars());
        StartCoroutine(creatorCarsTwo());
        StartCoroutine(creatorCarsThree());
        StartCoroutine(creatorCarsFour());
    }

    void Update(){
        
    }

    IEnumerator creatorCars(){        
        yield return new WaitForSeconds(3.0f);
        while (true){
            GameObject car = cars[Random.Range(0, cars.Length)];
            car.transform.position = GameObject.FindWithTag("generatorOne").transform.position;
            car.transform.rotation = GameObject.FindWithTag("generatorOne").transform.rotation;
            Instantiate(car);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
        }
    }

    IEnumerator creatorCarsTwo()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            GameObject car = cars[Random.Range(0, cars.Length)];
            car.transform.position = GameObject.FindWithTag("generatorTwo").transform.position;
            car.transform.rotation = GameObject.FindWithTag("generatorTwo").transform.rotation;
            Instantiate(car);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
        }
    }

    IEnumerator creatorCarsThree()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            GameObject car = cars[Random.Range(0, cars.Length)];
            car.transform.position = GameObject.FindWithTag("generatorThree").transform.position;
            car.transform.rotation = GameObject.FindWithTag("generatorThree").transform.rotation;
            Instantiate(car);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
        }
    }

    IEnumerator creatorCarsFour()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            GameObject car = cars[Random.Range(0, cars.Length)];
            car.transform.position = GameObject.FindWithTag("generatorFour").transform.position;
            car.transform.rotation = GameObject.FindWithTag("generatorFour").transform.rotation;
            Instantiate(car);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
        }
    }
}
