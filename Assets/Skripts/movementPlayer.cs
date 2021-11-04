using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movementPlayer : MonoBehaviour
{
    Rigidbody2D body;
    public Animator anim;
    public Manager Mgmt;
    public Slider PsstSlider;

    private float PsstCoolDown = 5.0f;


    float horizontal;
    float vertical;

    public float runSpeed = 1.0f;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {


        if(PsstCoolDown > 0) {
            PsstCoolDown -= Time.deltaTime;
            PsstSlider.value = PsstCoolDown;
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
            if(PsstCoolDown <= 0) {
                psstFunction();
            }
            
        } else if(Input.GetKeyDown(KeyCode.E) && Mgmt.GetInteraktiv() == true) {
            Mgmt.startQuest();
        }


    }
    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    private void psstFunction() {
        this.Mgmt.removeVolumeValue(20);
        PsstCoolDown = 5.0f;
    }
}
