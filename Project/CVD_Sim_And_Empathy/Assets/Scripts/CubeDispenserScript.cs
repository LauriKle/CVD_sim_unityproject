using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDispenserScript : MonoBehaviour
{
    public float dispenseInterval = 2.0f;
    private float timerCount;
    public Vector3 offset;
    public GameObject[] items;
    private int i;

    private int[] itemList = new int[] {
        0b001,
        0b010,
        0b100,
        0b111
    };

    public bool isRunning;

    void Start()
    {
        i = 0;
        timerCount = dispenseInterval;
    }

    void Update()
    {
        if (isRunning)
        {
            timerCount -= Time.deltaTime;
            if (timerCount <= 0)
            {
                timerCount = dispenseInterval;
                dispenseCube();
            }
        }
    }
    
    public void switchOnOrOff(){
        isRunning = !isRunning;
    }
        
    void dispenseCube(){
        GameObject clone;
        if (isRunning == true) {
            for (int n = 0; n < 3; ++n)
            {
                if ((itemList[i] & (1 << n)) > 0)
                {
                    clone = Instantiate(items[n], transform.position + offset * n, Quaternion.identity) as GameObject;
                }
            }
            i = (i + 1) % itemList.Length;             
                
           
        }
    }
}
