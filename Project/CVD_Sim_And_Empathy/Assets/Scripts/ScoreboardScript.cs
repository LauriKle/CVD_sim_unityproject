using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    public GameObject missedCounterObject;
    public GameObject correctCounterObject;
    
    public int missed;
    public int correct;
    
    // Start is called before the first frame update
    void Start()
    {
        missed = 0;
        correct = 0;
        updateCounters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void incrementMissed(int amount){
        missed += amount;
        updateCounters();
    }
    
    public void incrementCorrect(int amount){
        correct += amount;
        updateCounters();
    }
    
    void updateCounters(){
        TextMesh missedTextObject = missedCounterObject.GetComponent<TextMesh>();
        missedTextObject.text = missed.ToString();
        TextMesh correctTextObject = correctCounterObject.GetComponent<TextMesh>();
        correctTextObject.text = correct.ToString();
    }
}
