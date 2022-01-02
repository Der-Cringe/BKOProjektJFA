using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class windowMinigame : MonoBehaviour
{
    //zeit in sec
    //Start Timer : 3 2 1 Los
    private double timerStart;


    //Objekt disappear Time    
    private double timeDis = 0.0f;

    public float randomWaitingTime;

    private bool windowOpened;

    private int score;
    public GameObject[] imgs;
    public GameObject empty;
    public Manager mgmt;

    public Text infoText;

    public GameObject startContainer;
    public Text startCountdown;

    public double uiTextTimer =  0;



    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer

        // if(this.gameObject.activeSelf) {
        //     Cursor.visible = false;
        //     Vector3 mousePos = Input.mousePosition;

        //     NFC_Chip.transform.position = mousePos;
        // }
        if(timerStart < 0.0f) {
            //Warum wird das immer wieder ausgeführt
            startContainer.SetActive(false);
    
            //Text Timer für oben
            if(uiTextTimer < 0.0f) {
                if(infoText.text != ""){
                    infoText.text = "";
                }
            } 
            else 
            {
                uiTextTimer -= Time.deltaTime;
            }


            if(windowOpened && uiTextTimer <= 0){
                finishMinigame();
            }
                    

        } else {
            startCountdown.text = timerStart.ToString("0");
            timerStart -= Time.deltaTime;
        }
        
    }


    public void setHardnessLvl(int hardnessValue){
       
    }


    public void resetMg() {
        timerStart = 1.0f;
        infoText.text = "";
        windowOpened = false;
            


        startContainer.SetActive(true);
        //curImg = empty;
        //this.gameObject.SetActive(false);

    }


    public void useHandleBtn(){
        writetoUI("Window opened!",2f);
        windowOpened = true;

    }

    public void finishMinigame(){
        mgmt.windowMinigameOver();
        resetMg();
        
    }

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }

}