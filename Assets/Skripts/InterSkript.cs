﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterSkript:MonoBehaviour {
    public GameObject player;
    public Manager mgmt;
    public int id;
    public float interactRange;

    void Update() {
        DetectIfPlayerIsInRange();
    }

    private void DetectIfPlayerIsInRange() {
        
        if(Vector2.Distance(player.transform.position,this.transform.position) < interactRange) {
            //Debug.Log("dudewhat id "+ id + this.gameObject + interactRange + "Dies: "+Vector2.Distance(player.transform.position,this.transform.position));
            mgmt.interaktivSet(true,this.gameObject,id);
        } else {
            mgmt.interaktivSet(false,this.gameObject,id);
        }
    }

}
