using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCskript:MonoBehaviour {

    // Update is called once per frame#
    public float TIME_CONTAINER = 3.0f;
    public Manager Mgmt;
    public bool picked;


    private float actionTimer;

    private void Start() {
        picked = false;
        actionTimer = TIME_CONTAINER;
    }
    public void talk(GameObject bubble) {
        Instantiate(bubble,this.transform.position,Quaternion.identity);
    }

}
