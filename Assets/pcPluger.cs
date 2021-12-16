using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pcPluger : MonoBehaviour{

    public GameObject Target;
    public GameObject empty;

    public GameObject rechts;
    public GameObject links;
    public GameObject[] spawnpoint;
    private int id;

    public GameObject Kabel;
    public GameObject Kabel_transparent;
    private bool isDragging;

    void Start() {
        Target = empty;
    }


    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if(isDragging == true) {
                Kabel.SetActive(true);
                Kabel_transparent.SetActive(false);
                isDragging = false;
            } else if(isDragging == false) {
                Kabel.SetActive(false);
                Kabel_transparent.SetActive(true);
                isDragging = true;
                Target = empty;

            }

        }
        if(isDragging) {
            Vector3 mousePos = Input.mousePosition;
            Target.transform.position = mousePos;
            
        }
    }
    public void change_target_to_left() {
        Target = links;
        id = 0;
    }
    public void change_target_to_right() {
        Target = rechts;
        id = 1;
    }
}
