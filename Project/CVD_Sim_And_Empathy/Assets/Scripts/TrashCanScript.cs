using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    public GameObject scoreboard;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 6){
            if (other.gameObject.name == "RedCube" | other.gameObject.name == "RedCube(Clone)" ){
                scoreboard.GetComponent<ScoreboardScript>().incrementMissed(1);
            }
            Destroy(other.transform.gameObject);
        }
    }
}
