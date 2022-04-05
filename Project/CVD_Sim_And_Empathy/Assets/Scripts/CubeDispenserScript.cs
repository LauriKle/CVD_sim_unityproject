using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDispenserScript : MonoBehaviour
{
    private int i;
    private readonly int[,] itemList = new int[8, 4]
    {
        {0, 0, 0, 0},
        {1, 1, 1, 1},
        {2, 2, 2, 2},
        {3, 3, 3, 3},
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0}
    };

    private int boxID;

    public enum States
    {
        IDLE = 0,
        NORMAL = 1,
        CVD = 2
    }

    public new GameObject camera;
    
    public Vector3[] offset;
    public GameObject[] items;
    

    void Start()
    {    
        i = 0;
        boxID = 0;
    }
     
    public bool dispenseCube()
    {
        GameObject clone;

        for (int n = 0; n < 4; ++n)
        {
            if (itemList[i, n] > 0)
            {
                clone = Instantiate(items[itemList[i, n] - 1], transform.position + offset[n], Quaternion.identity) as GameObject;
                clone.name = clone.name + (++boxID);
            }
        }
        i = (i + 1) % itemList.GetLength(0);             
        if (i == 0)
        {
            boxID = 0;
            return true;
        }
        return false;
    }
}
