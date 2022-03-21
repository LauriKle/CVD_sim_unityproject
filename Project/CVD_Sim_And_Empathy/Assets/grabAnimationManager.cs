using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabAnimationManager : MonoBehaviour
{
    public InputActionReference grabReference = null;
    public bool grabbing = false;
    public float grabAnimationSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void OnDestroy(){

    }
    
    void Update()
    {
        float grabValue = grabReference.action.ReadValue<float>();
        updateAnimations(grabValue);
    }
    
    void updateAnimations(float grabVal){
        if (grabVal <= 0.5){
            GetComponent<Animator>().CrossFade("not grabbing",grabAnimationSpeed);
        }else{
           GetComponent<Animator>().CrossFade("grabbing",grabAnimationSpeed);
        }
            
    }
}
