using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCskript:MonoBehaviour {

    // Update is called once per frame#
    public float TIME_CONTAINER = 3.0f;
    public Manager Mgmt;

    private float actionTimer;

    private void Start() {
        actionTimer = TIME_CONTAINER;
        Mgmt.goToTeacherTable();
    }
    void Update() {

        //Periodic Mechanism to add Dezible
        if(actionTimer > 0) {
            actionTimer -= Time.deltaTime;
        } else {
            if(this.gameObject.tag == "felix") {
                FelixPattern();
            }
            actionTimer = TIME_CONTAINER;
        }

    }
    private void FelixPattern() {
        this.Mgmt.AddVolumeValue(2);
    }
}
