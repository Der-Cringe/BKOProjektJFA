using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript:MonoBehaviour {
    public movementPlayer Player;
    public GameObject miniGame;

    private bool touched = false;
    private void Start() {
        if(miniGame.activeSelf) {
            miniGame.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Player.setMiniGame(miniGame);
        }
    }
}
