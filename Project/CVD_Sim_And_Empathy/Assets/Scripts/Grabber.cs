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
    
    private InputDevice RightXRController;
    private InputDevice LeftXRController;
    
    private Vector3 controllerVelocity;
    private Vector3 controllerAngularVelocity;
     
    void Start()
    {
        watcher.triggerButtonPress.AddListener(onTriggerButtonEvent);
        RightXRController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        LeftXRController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }
    
    public void onTriggerButtonEvent(bool pressed)
    {
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
            grabbableItems.Add(other.transform.gameObject);
        }
    }
    
    void OnTriggerExit(Collider other) {
        if (grabbableItems.Contains(other.transform.gameObject)){
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
    
    void getControllerVelocities(){
        RightXRController.TryGetFeatureValue(CommonUsages.deviceVelocity, out controllerVelocity);
        RightXRController.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out controllerAngularVelocity);
    }
    
    void stopGrab(){
        if (grabbing == true){
            {
                grabbing = false;
                print("Let go of this object:" +  grabbedObject.name);
                var g = grabbedObject.GetComponent<GrabbableScript>();
                
                getControllerVelocities();
                g.stopGrabbing(gameObject, controllerVelocity, controllerAngularVelocity);
                grabbedObject = null;
            }
        }
    }
}
