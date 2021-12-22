using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySkript : MonoBehaviour
{

    public GameObject start;
    public GameObject options;
    public void Play() {
        SceneManager.LoadScene("tutorialScene");
    }

    public void Options(){
        start.SetActive(false);
        options.SetActive(true);
    }

    public void backToStart(){
        start.SetActive(true);
        options.SetActive(false);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Start() {
        options.SetActive(false);
    }


}
