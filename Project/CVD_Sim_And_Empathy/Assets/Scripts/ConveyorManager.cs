using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public GameObject belt;
    public GameObject itemDispenser;
    public GameObject mainCamera;
    public float dispenseInterval = 2.0f;
    public enum States
    {
        IDLE = 0,
        NORMAL = 1,
        CVD = 2,
        STOP = 3
    }

    private States state = States.IDLE;
    private float timerCount;

    void Update()
    {
        switch (state)
        {
            case States.IDLE:
            case States.STOP:
                break;

            case States.NORMAL:
            case States.CVD:
                timerCount -= Time.deltaTime;
                if (timerCount <= 0)
                {
                    timerCount = dispenseInterval;
                    if (itemDispenser.GetComponent<CubeDispenserScript>().dispenseCube())
					{
                        NextState();
					}
                }
                break;
        }
        
    }

    public void NextState()
    {
        switch (state)
        {
            case States.IDLE:
                timerCount = dispenseInterval;
                belt.GetComponent<ConveyorScript>().switchOnOrOff();
                state = States.NORMAL;
                break;
            case States.NORMAL:
                mainCamera.GetComponent<ColorBlindFilter>().ToggleColors();
                state = States.CVD;
                break;
            case States.CVD:
                belt.GetComponent<ConveyorScript>().switchOnOrOff();
                state = States.STOP;
                break;
            case States.STOP:
                break;
        }
    }

    public void ButtonPressed()
    {
        if (state == States.IDLE)
        {
            NextState();
        }

    }
}





