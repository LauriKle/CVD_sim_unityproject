using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDispenserScript : MonoBehaviour
{
    public float dispenseInterval = 2.0f;
    private float timerCount;
    
    public List<GameObject> itemsToDispense;
    public bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        timerCount = dispenseInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timerCount -= Time.deltaTime;
        
        if (timerCount <= 0){
            timerEnd();
        }
    }
    
    public void switchOnOrOff(){
        isRunning = !isRunning;
    }
    
    void timerEnd(){
        timerCount = dispenseInterval;
        dispenseCube();
    }
    
    void dispenseCube(){
        if (isRunning == true){
            if (itemsToDispense.Count > 1){
                int itemListIndex = Random.Range(0, (itemsToDispense.Count));
                if (itemsToDispense[itemListIndex] != null){
                    GameObject clone = Instantiate(itemsToDispense[itemListIndex], transform.position, Quaternion.identity) as GameObject;
                }
                else{
                    print("An item in the list was null!");
                }
            }
            else
                print("Item list is empty");
        }
    }
}
