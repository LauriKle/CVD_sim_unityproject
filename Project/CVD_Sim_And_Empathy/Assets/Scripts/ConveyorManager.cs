using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public GameObject belt;
    public GameObject itemDispenser;
    public GameObject mainCamera;

    public float dispenseInterval = 2.0f;

    private float timerCount;
    private bool pressedBefore = false;

    public enum States
    {
        IDLE = 0,
        NORMAL = 1,
        CVD = 2
    }
    public States state = States.IDLE;

    void Start()
    {
        state = States.IDLE;
        timerCount = dispenseInterval;      
    }
   
    void Update()
    {
        switch (state)
        {
            case States.IDLE:
                break;
            case States.NORMAL:
            case States.CVD:
                timerCount -= Time.deltaTime;
                if (timerCount <= 0)
                {
                    timerCount = dispenseInterval;
                    if (itemDispenser.GetComponent<CubeDispenserScript>().dispenseCube())
					{
                        nextState();
					}
                }
                break;
        }
        
    }

    public void nextState()
    {
        switch (state)
        {
            case States.IDLE:
                belt.GetComponent<ConveyorScript>().switchOnOrOff();
                state = States.NORMAL;
                break;
            case States.NORMAL:
                mainCamera.GetComponent<ColorBlindFilter>().ToggleColors();
                state = States.CVD;
                break;
            case States.CVD:
                belt.GetComponent<ConveyorScript>().switchOnOrOff();
                mainCamera.GetComponent<ColorBlindFilter>().ToggleColors();
                state = States.IDLE;
                break;
        }
    }

    public void buttonPressed()
    {
        if (state == States.IDLE && !pressedBefore)
        {
            pressedBefore = true;
            nextState();
        }

    }
}





