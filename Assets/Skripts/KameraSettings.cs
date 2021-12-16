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
<<<<<<< HEAD
       
=======
>>>>>>> eb2c179c8de73a9828ab66b9306cceb04a4410df
        if(Input.GetKey(KeyCode.Z)) {
            if(cam.orthographicSize < 2) {
                cam.orthographicSize += 1 * Time.deltaTime;
            }
        } else if (Input.GetKey(KeyCode.U)) {
            if(cam.orthographicSize > 1) {
                cam.orthographicSize -= 1 * Time.deltaTime;
            }
        }
    }
}
