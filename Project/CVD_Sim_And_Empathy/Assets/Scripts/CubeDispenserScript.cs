using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDispenserScript : MonoBehaviour
{
    private float timerCount;
    private int i;
    private readonly int[,] itemList = new int[5, 4]
    {
        {0, 0, 0, 0},
        {1, 1, 1, 1},
        {2, 2, 2, 2},
        {3, 3, 3, 3},
        {0, 0, 0, 0}
    };

    public enum States
    {
        IDLE = 0,
        NORMAL = 1,
        CVD = 2
    }

    public float dispenseInterval = 2.0f;
    public Vector3[] offset;
    public GameObject[] items;
    // Testauksen takia public, vaiha private kun testaus on tehty
    public States state = States.IDLE;

    void Start()
    {
        //state = States.IDLE;
        i = 0;
        timerCount = dispenseInterval;
    }

    void Update()
    {
        switch (state)
        {
            case States.IDLE:
                break;
            case States.NORMAL:
                timerCount -= Time.deltaTime;
                break;
            case States.CVD:
                timerCount -= Time.deltaTime;
                break;   
        }
        if (timerCount <= 0)
        {
            timerCount = dispenseInterval;
            dispenseCube();
        }
    }
    
    public void nextState(){
        switch (state)
        {
            case States.IDLE:
                state = States.NORMAL;
                break;
            case States.NORMAL:
                // lerp
                state = States.CVD;
                break;
            case States.CVD:
                // lerp off
                state = States.IDLE;
                break;
        }
    }
        
    void dispenseCube(){
        GameObject clone;
        
        for (int n = 0; n < 4; ++n)
        {
            if (itemList[i, n] > 0)
            {
                clone = Instantiate(items[itemList[i, n] - 1], transform.position + offset[n], Quaternion.identity) as GameObject;
            }
        }
        i = (i + 1) % itemList.GetLength(0);             
        if (i == 0)
        {
            nextState();
        }
    }
}
