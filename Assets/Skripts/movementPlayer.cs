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
    public AudioSource Foodsteps;
    public AudioSource StartCountDownAudio;

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
            Foodsteps.Play();
            anim.SetBool("up", true);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Foodsteps.Play();
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("left", true);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Foodsteps.Play();
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("right", true);
            anim.SetBool("left", false);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Foodsteps.Play();
            anim.SetBool("up", false);
            anim.SetBool("down", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
        } else if(Input.GetKeyDown(KeyCode.Q)) {
            Foodsteps.Play();
            //PSSST Function
            if(PsstCoolDown <= 0) {
                psstFunction();
            }
            
        } else if(Input.GetKeyDown(KeyCode.E)) {
           
            switch (Mgmt.InteraktId){
                case 0:
                    Mgmt.doorMinigame();
                break;
                case 1:
                    Mgmt.startQuest(1);
                break;
                case 2:
                    if(Mgmt.pcStuck == false)
                    {
                        Mgmt.startQuest(2);
                    }
                    
                break;
                case 3:
                    Mgmt.quizabcMinigame();
                break;
                case 4:
                if(Mgmt.windowClosed == true) {
                    Mgmt.windowMinigame();
                }
                break;
                case 5:
                    Mgmt.loginMinigame();
                break;
                default:
                Debug.Log("No");
                break;
            }
        }


        if(!Input.anyKey) {
            Foodsteps.Stop();
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
