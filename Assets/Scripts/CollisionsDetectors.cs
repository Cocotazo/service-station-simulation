using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsDetectors : MonoBehaviour
{

    //public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.parent.gameObject.SendMessage("inCollision");
        Debug.Log("collision");
    }

    private void OnCollisionExit(Collision collision)
    {
        gameObject.transform.parent.gameObject.SendMessage("outCollision");
    }
}
