using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class doorMinigameScript : MonoBehaviour
{
    //zeit in sec
    //Start Timer : 3 2 1 Los
    private double timerStart;


    //Objekt disappear Time    
    private double timeDis = 0.0f;

    public float randomWaitingTime;
    bool canbeOpened;

    private int score;
    public GameObject[] imgs;
    public GameObject empty;
    public Manager mgmt;

    public Text infoText;

    public GameObject startContainer;
    public Text startCountdown;

    public double uiTextTimer =  0;

    public bool isWaitingOver;


    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer

                  
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

            // Waiting time for the Button lock open
            if(randomWaitingTime < 0.0f){
                isWaitingOver = true;
            }
            else 
            {
                randomWaitingTime -= Time.deltaTime;
            }
                    

        } else {
            startCountdown.text = timerStart.ToString("0");
            timerStart -= Time.deltaTime;
        }
        
    }


    public void setHardnessLvl(int hardnessValue){
       
    }


    public void resetMg() {
        randomWaitingTime = Random.Range(2,12);
        timerStart = 3.0f;
        canbeOpened = false;
        isWaitingOver = false;



        
        startContainer.SetActive(true);
        //curImg = empty;
        timer = timeMg;
        this.gameObject.SetActive(false);

    }


    public void useLockBtn(){
        if(isWaitingOver){
            canbeOpened = true;
            writetoUI("Unlocked!",2f);
        }
        else{
            writetoUI("Nope!",1f);
        }
    }

    public void useHandleBtn(){
        if(canbeOpened){
            writetoUI("Congrats",3f);
            if(uiTextTimer <= 0){
                finishMinigame();
            }
        }
        else{
            writetoUI("Not Unlocked",3f);
        }
    }

    public void finishMinigame(){

    }

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }

}