using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleskript : MonoBehaviour
{
    private double killTimer = 2.0f;
    void Update()
    {
        if(killTimer < 0.0f) {
            Destroy(this.gameObject);
        } else {
            killTimer -= Time.deltaTime;
        }
    }
}
