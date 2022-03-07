using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    
    public float conveyorSpeed = 500.0f;
    public Vector3 conveyorDirection;
    
    private Vector3 direction;
    
    void OnCollisionStay(Collision other) {
        if (other.gameObject.layer == 6){
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity = conveyorSpeed * conveyorDirection * Time.deltaTime ;
        }
    }
}
