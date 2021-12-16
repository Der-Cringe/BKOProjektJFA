using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pcPluger : MonoBehaviour{

    public Image img;
    private bool isDragging;

    public void OnMouseDown() {
        
        Debug.Log("tst");
    }

    public void OnMouseUp() {
        isDragging = false;
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
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //transform.Translate(mousePosition);
            Vector3 mousePos = Input.mousePosition;
            img.transform.position = mousePos;
            
        }

    }
}
