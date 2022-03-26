using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public GameObject belt;
    public List<GameObject> itemDispensers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void switchOnOrOff(){
        belt.GetComponent<ConveyorScript>().switchOnOrOff();
        foreach(GameObject dispenser in itemDispensers){
            dispenser.GetComponent<CubeDispenserScript>().switchOnOrOff();
        }
    }
}
