using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
