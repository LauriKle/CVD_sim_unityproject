// Alan Zucconi
// www.alanzucconi.com
using UnityEngine;
using System.Collections;

public enum ColorBlindMode
{
    Normal = 0,
    Protanopia = 1,
    Protanomaly = 2,
    Deuteranopia = 3,
    Deuteranomaly = 4,
    Tritanopia = 5,
    Tritanomaly = 6,
    Achromatopsia = 7,
    Achromatomaly = 8,
}

[ExecuteInEditMode]
public class ColorBlindFilter : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public ColorBlindMode mode = ColorBlindMode.Normal;
    private ColorBlindMode previousMode = ColorBlindMode.Normal;
    public float filterStrength = 0f;
    public float previousFilterStrength = 0f;
    public bool showDifference = false;
    public bool lerping = false;


    private Material material;
    public float lerpDuration = 10; 
    public float startValue = 0; 
    public float lerpTarget = 1f;

    private static Color[,] RGB =
    {
        { new Color(1f,0f,0f),   new Color(0f,1f,0f), new Color(0f,0f,1f) },    // Normal
        { new Color(.56667f, .43333f, 0f), new Color(.55833f, .44167f, 0f), new Color(0f, .24167f, .75833f) },    // Protanopia
        { new Color(.81667f, .18333f, 0f), new Color(.33333f, .66667f, 0f), new Color(0f, .125f, .875f)    }, // Protanomaly
        { new Color(.625f, .375f, 0f), new Color(.70f, .30f, 0f), new Color(0f, .30f, .70f)    },   // Deuteranopia
        { new Color(.80f, .20f, 0f), new Color(.25833f, .74167f, 0), new Color(0f, .14167f, .85833f)    },    // Deuteranomaly
        { new Color(.95f, .05f, 0), new Color(0f, .43333f, .56667f), new Color(0f, .475f, .525f) }, // Tritanopia
        { new Color(.96667f, .03333f, 0), new Color(0f, .73333f, .26667f), new Color(0f, .18333f, .81667f) }, // Tritanomaly
        { new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f)  },   // Achromatopsia
        { new Color(.618f, .32f, .062f), new Color(.163f, .775f, .062f), new Color(.163f, .320f, .516f)  }    // Achromatomaly
    };
    
    void Start(){
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
       // float lerpTarget = 1f;
        //StartCoroutine(Lerp(lerpTarget));
    }
    
    void Awake()
    {
        material = new Material(Shader.Find("Hidden/ChannelMixer"));
        material.SetColor("_R", RGB[0, 0]);
        material.SetColor("_G", RGB[0, 1]);
        material.SetColor("_B", RGB[0, 2]);
    }
    
    public void onPrimaryButtonEvent(bool pressed){
        if (pressed == true && lerping == false){
            print("juu painoit nappia, lerptarget on " + lerpTarget);
            StartCoroutine(Lerp(lerpTarget));
            if (lerpTarget == 0f){
                lerpTarget = 1f;
            }else if (lerpTarget == 1f){
                lerpTarget = 0f;
            }else{
                print("something went wrong????");
            }
        }
    }
    
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // No effect
        if (mode == ColorBlindMode.Normal)
        {
            Graphics.Blit(source, destination);
            return;
        }

        // Change effect
        if (mode != previousMode | filterStrength != previousFilterStrength)
        {
            material.SetColor("_R", RGB[(int)mode, 0] * filterStrength + RGB[0, 0] * (1 - filterStrength));
            material.SetColor("_G", RGB[(int)mode, 1] * filterStrength + RGB[0, 1] * (1 - filterStrength));
            material.SetColor("_B", RGB[(int)mode, 2] * filterStrength + RGB[0, 2] * (1 - filterStrength));
            previousMode = mode;
        }

        // Apply effect
        Graphics.Blit(source, destination, material, showDifference ? 1 : 0);
    }
    
    IEnumerator Lerp(float lerpEndValue){
        lerping = true;
        float lerpStartValue = filterStrength;
        float timeElapsed = 0;
        print("filterstrength: " + filterStrength +  ", lerp end value: " + lerpEndValue);
        while (timeElapsed < lerpDuration)
        {
            previousFilterStrength = filterStrength;
            filterStrength = Mathf.Lerp(lerpStartValue, lerpEndValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        filterStrength = lerpEndValue;
        previousFilterStrength = filterStrength;
        lerping = false;
    }
}