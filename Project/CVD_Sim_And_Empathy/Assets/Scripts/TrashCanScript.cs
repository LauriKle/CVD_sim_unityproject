using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    public GameObject scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.Find("Scoreboard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 6){
            Destroy(other.transform.gameObject);
            scoreboard.GetComponent<ScoreboardScript>().incrementMissed(1);
        }
    }
    
    
}
