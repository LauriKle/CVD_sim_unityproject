using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButtonScript : MonoBehaviour
{
    public AudioClip buttonPressAudioClip;    
    AudioSource audioSource;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.transform.gameObject.tag == "Player Hand Controller"){
            audioSource.PlayOneShot(buttonPressAudioClip);
            manager.GetComponent<ConveyorManager>().switchOnOrOff();
        }
    }
}
