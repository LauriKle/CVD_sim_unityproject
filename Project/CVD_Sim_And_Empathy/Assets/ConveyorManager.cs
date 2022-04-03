using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public GameObject belt;
    public GameObject itemDispenser;
    
    public void switchOnOrOff(){
        if (itemDispenser.GetComponent<CubeDispenserScript>().state == CubeDispenserScript.States.IDLE)
        {
            itemDispenser.GetComponent<CubeDispenserScript>().nextState();
            belt.GetComponent<ConveyorScript>().switchOnOrOff();
        }
        
    }
}
