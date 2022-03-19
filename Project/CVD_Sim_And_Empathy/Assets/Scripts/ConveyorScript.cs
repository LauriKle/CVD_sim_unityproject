using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    public Vector2 scroll = new Vector2 (0.05f , 0.05f);
    Vector2 offset = new Vector2 (0f, 0f);
    
    public float conveyorSpeed = 500.0f;
    public Vector3 conveyorDirection;
    
    public List<GameObject> itemsToConvey;
    
    
   // private Vector3 direction;
    
    void Update () {
        //Scroll texture
        offset +=  scroll * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
        
        //Move items on the conveyor
        int l = itemsToConvey.Count;
        if (l > 0){
            foreach (GameObject item in itemsToConvey){
                Rigidbody rigidbody = item.GetComponent<Rigidbody>();
                rigidbody.velocity = conveyorSpeed * conveyorDirection * Time.fixedDeltaTime ;
            }
        }
    }


    void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 6){
            itemsToConvey.Add(other.transform.gameObject);
        }
    }
    
    void OnCollisionExit(Collision other) {
        if (itemsToConvey.Contains(other.transform.gameObject)){
            itemsToConvey.Remove(other.transform.gameObject);
        }
    }
}
