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
        Vector2 bubblePos = new Vector2(this.transform.position.x + Random.Range(0.5f,1.5f),this.transform.position.y + Random.Range(0.5f,2.5f));
        Instantiate(bubble,bubblePos,Quaternion.identity);
    }

}
