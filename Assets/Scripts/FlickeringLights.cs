using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public bool isOn;
    public float onMax;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        onMax = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        if(Random.Range(0f,10f) > onMax) {
            isOn = false;
        }
        else {
            isOn = true;
        }

        
    }
}
