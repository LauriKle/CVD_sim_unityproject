using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    public GameObject missedCounterObject;
    public GameObject correctCounterObject;
    
    private int missed;
    private int correct;
    
    public AudioClip correctAudioClip;
    public AudioClip incorrectAudioClip;
    
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        missed = 0;
        correct = 0;
        updateCounters();
        audioSource = GetComponent<AudioSource>();
    }
    
    public void incrementMissed(int amount){
        missed += amount;
        updateCounters();
        audioSource.PlayOneShot(incorrectAudioClip);
    }
    
    public void incrementCorrect(int amount){
        correct += amount;
        updateCounters();
        audioSource.PlayOneShot(correctAudioClip);
    }
    
    void updateCounters(){
        TextMesh missedTextObject = missedCounterObject.GetComponent<TextMesh>();
        missedTextObject.text = missed.ToString();
        TextMesh correctTextObject = correctCounterObject.GetComponent<TextMesh>();
        correctTextObject.text = correct.ToString();
    }
}
