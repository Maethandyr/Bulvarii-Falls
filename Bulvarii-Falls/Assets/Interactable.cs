using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour

{
    private GameObject rock;


        //Update is called once per frame
 void Update()
        {

        }
    

    void OnTriggerStay2D(Collider2D other)

        {
            
            other.attachedRigidbody.AddForce(-0.1F * other.attachedRigidbody.velocity);
        }
}
