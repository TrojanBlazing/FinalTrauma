using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    [SerializeField] GameObject lights;
    bool lightsOn;

    private void Awake()
    {
        lightsOn = true;
    }
    internal void ToggleLights()
    {
        if(lightsOn)
        {
            lights.SetActive(false);
            lightsOn = false;
        }
        else if(!lightsOn) 
        {
            lights.SetActive(true);
            lightsOn = true;
        }

    }
}
