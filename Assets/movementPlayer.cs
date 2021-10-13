using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movementPlayer : MonoBehaviour
{
    Rigidbody2D body;
    public Animator anim;
    public Manager mgmt;
    public Slider PsstSlider;

    private float psstCoolDown = 5.0f;


    float horizontal;
    float vertical;

    public float runSpeed = 1.0f;


    private GameObject curMiniGame;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {


        if(psstCoolDown > 0) {
            psstCoolDown -= Time.deltaTime;
            PsstSlider.value = psstCoolDown;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //Action Buttons 
        if (Input.GetKeyDown(KeyCode.W)) {
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", true);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", true);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            anim.SetBool("up", false);
            anim.SetBool("down", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        } else if(Input.GetKeyDown(KeyCode.Q)) {
            //PSSST Function
            if(psstCoolDown <= 0) {
                psstFunction();
            }   
        }else if(Input.GetKeyDown(KeyCode.E)) {
            startMiniGame();
        }
        

    }
    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    private void psstFunction() {
        this.mgmt.removeVolumeValue(20);
        psstCoolDown = 5.0f;
    }
    private void startMiniGame() {
        curMiniGame.SetActive(true);
    }
    public void setMiniGame(GameObject uMG) {
        curMiniGame = uMG;
    }
}
