using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pcPluger : MonoBehaviour{

    public Image img;
    private bool isDragging;

    public LineRenderer line;
    public DistanceJoint2D joint;
    DistanceJoint2D rope;

    bool checker;

    void Start() {
        gameObject.AddComponent<LineRenderer>();
    }


    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if(isDragging == true) {
                isDragging = false;
            } else if(isDragging == false) {
                isDragging = true;
            }

        }
        if(isDragging) {
            Vector3 mousePos = Input.mousePosition;
            img.transform.position = mousePos;
            
        }
    }

}
