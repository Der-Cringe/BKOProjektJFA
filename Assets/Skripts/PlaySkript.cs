using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySkript : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("main");
    }
}
