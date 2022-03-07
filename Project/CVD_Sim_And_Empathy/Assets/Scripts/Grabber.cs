using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Grabber : MonoBehaviour
{
    public TriggerButtonWatcher watcher;
    public bool isTryingToGrab;
    public List<GameObject> grabbableItems;
    public bool grabbing;
    public GameObject grabbedObject;
   // public collider grabCollider = Collider;
    // Start is called before the first frame update
    void Start()
    {
        watcher.triggerButtonPress.AddListener(onTriggerButtonEvent);
    }
    
    public void onTriggerButtonEvent(bool pressed)
    {
        print("detected button press");
        if (pressed){
            isTryingToGrab = true;
            attemptToGrab();
        }
        else
            stopGrab();
            isTryingToGrab = false;
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.layer == 6){
            print("controller entered a grabbable collider");
            grabbableItems.Add(other.transform.gameObject);
        }
    }
    
    void OnTriggerExit(Collider other) {
        if (grabbableItems.Contains(other.transform.gameObject)){
            print("COntroller exited a grabbable collider");
            grabbableItems.Remove(other.transform.gameObject);
        }
    }
    
    void attemptToGrab(){
        if (grabbing == false){
            int l = grabbableItems.Count;
            if (l > 0){
                GameObject item = grabbableItems[0];
                grabbing = true;
                print("TRIED TO GRAB THIS OBJECT:" +  item.name);
                var g = item.GetComponent<GrabbableScript>();
                g.startGrabbing(gameObject);
                grabbedObject = item;
                grabbableItems.Clear();
            }
        }
    }
    
    void stopGrab(){
        if (grabbing == true){
            {
                grabbing = false;
                print("Let go of this object:" +  grabbedObject.name);
                var g = grabbedObject.GetComponent<GrabbableScript>();
                g.stopGrabbing(gameObject);
                grabbedObject = null;
            }
        }
    }
}
