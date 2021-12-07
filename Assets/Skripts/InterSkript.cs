using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterSkript:MonoBehaviour {
    public GameObject player;
    public Manager mgmt;
    public float interactRange;

    void Update() {
        DetectIfPlayerIsInRange();
    }

    private void DetectIfPlayerIsInRange() {
        if(Vector2.Distance(player.transform.position,this.transform.position) < interactRange) {
            mgmt.interaktivSet(true,this.gameObject);
        } else {
            mgmt.interaktivSet(false,this.gameObject);
        }
    }

}
