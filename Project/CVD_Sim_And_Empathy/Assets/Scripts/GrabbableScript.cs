using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableScript : MonoBehaviour
{
    private Collider coll;
    private Rigidbody rb;
    public List<GameObject> potentialAnchorPoints;

    public void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    public void startGrabbing(GameObject grabber) {
        coll.enabled = false;
        rb.isKinematic = true;
        transform.SetParent(grabber.transform);
    }
    
    public void stopGrabbing(GameObject grabber, Vector3 vel, Vector3 angularVel){
        if (potentialAnchorPoints.Count == 0){ //If there are no anchor points that the object could be set into, turn physics back on and remove parent hierarchy
            rb.velocity = vel;
            rb.angularVelocity = angularVel;
            coll.enabled = true;
            rb.isKinematic = false;
            transform.SetParent(null);
        }
        else{
            GameObject anchor = potentialAnchorPoints[0];
            setIntoAnchor(anchor);
        }
    }
    
    private void setIntoAnchor(GameObject anchor){
        potentialAnchorPoints.Clear();
        coll.enabled = true;
        rb.isKinematic = true;
        transform.SetParent(anchor.transform);
        transform.localPosition = Vector3.zero;
    }
    
    void OnTriggerEnter(Collider other) {
        GameObject obj = other.transform.gameObject;
        if (obj.layer == 7){
            if ( !potentialAnchorPoints.Contains(obj)){
                potentialAnchorPoints.Add(obj);
            }
        }
    }
    
    private void OnTriggerExit(Collider other){
        if (other.transform.gameObject.layer == 7){
            potentialAnchorPoints.Remove(other.transform.gameObject);
        }
    }
}
