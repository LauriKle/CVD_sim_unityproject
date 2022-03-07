using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableScript : MonoBehaviour
{
        Collider coll;
        Rigidbody rigidb;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        rigidb = GetComponent<Rigidbody>();
    }

    public void startGrabbing(GameObject grabber) {
        coll.enabled = false;
        rigidb.isKinematic = true;
        transform.SetParent(grabber.transform);
    }
    
    public void stopGrabbing(GameObject grabber){
        coll.enabled = true;
        rigidb.isKinematic = false;
        transform.SetParent(null);
    }
}
