using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSettings : MonoBehaviour
{
    public Camera cam;
    public double size = 10;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.orthographicSize);
        if(Input.GetKey(KeyCode.Plus)) {
            if(cam.orthographicSize < 2) {
                cam.orthographicSize += 1 * Time.deltaTime;
            }
        } else if (Input.GetKey(KeyCode.Minus)) {
            if(cam.orthographicSize > 1) {
                cam.orthographicSize -= 1 * Time.deltaTime;
            }
        }
    }
}
