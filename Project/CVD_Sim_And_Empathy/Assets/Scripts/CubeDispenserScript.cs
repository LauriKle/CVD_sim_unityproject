using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDispenserScript : MonoBehaviour
{
    private int i = 0;
    private int boxID = 0;
    private readonly int[,] itemList = new int[,]
    {
        {0, 0, 0, 0}, // Etu bufferi

        {1, 0, 0, 0}, // Helppo
        {0, 2, 0, 0},
        {0, 0, 3, 0},
        {0, 0, 0, 2},
        {0, 0, 3, 0},
        {0, 1, 0, 0},
        

        {2, 3, 0, 0}, // Normaali
        {1, 1, 0, 0},
        {3, 1, 0, 0},
        {2, 2, 0, 0},
        {3, 2, 0, 0},
        {3, 3, 0, 0},
       

        {1, 2, 3, 0}, // Haastava
        {2, 2, 1, 0},
        {3, 1, 3, 0},
        {2, 3, 1, 0},
        {3, 2, 3, 0},
        {2, 1, 1, 0},
       

        {1, 2, 3, 1}, // Vaikea
        {3, 2, 2, 1},
        {3, 1, 3, 1},
        {1, 3, 2, 2},
        {3, 2, 3, 1},
        {3, 1, 2, 2},

        {0, 0, 0, 0}, // Taka bufferi
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0},
        {0, 0, 0, 0}
    };

    public enum States
    {
        IDLE = 0,
        NORMAL = 1,
        CVD = 2
    }

    public Vector3[] offset;
    public GameObject[] items;

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
        return i == 0;
    }
}
