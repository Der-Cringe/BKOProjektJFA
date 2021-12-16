using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameEndskript : MonoBehaviour
{
    public GameObject thisObj;
    public Text scoreText;
    public Manager mgmt;
    void Start()
    {
        thisObj.SetActive(false);
    }
    void Update()
    {
        scoreText.text = mgmt.get_score().ToString("0") + "%";
    }
}
