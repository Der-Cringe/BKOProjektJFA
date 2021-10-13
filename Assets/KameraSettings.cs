﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSettings : MonoBehaviour
{
    public Camera cam;
    public double size = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
            cam.orthographicSize  += 1*Time.deltaTime;
        } else if (Input.GetKey(KeyCode.O)) {
            cam.orthographicSize  -= 1*Time.deltaTime;
        }
    }
}