using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class loginMinigame : MonoBehaviour
{
    //zeit in sec
    //Start Timer : 3 2 1 Los
    private double timerStart;

    public Text timerTxt;

    //Objekt disappear Time    
    private double timeDis = 0.0f;

    private int score;
    public Text scoreTxt;
    public GameObject[] imgs;
    public GameObject empty;
    public Manager mgmt;

    public Text infoText;

    public GameObject startContainer;
    public Text startCountdown;

    public double uiTextTimer =  0;


    public GameObject userNameInput;
    public GameObject passwortInput;
    public string vorname;
    public string nachname;

    private string rightUsername;



    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer

        if(timerStart < 0.0f) {
            //Warum wird das immer wieder ausgeführt
            startContainer.SetActive(false);

                if(timeDis < 0.0f) {
                    finishMinigame();
                    resetMg();
                }
                else{
                    timeDis -= Time.deltaTime;
                    /*

                        ---- Zeug für Update

                    */
                    if(uiTextTimer < 0.0f) {
                        if(infoText.text != ""){
                            infoText.text = "";
                        }
                    } 
                    else 
                    {
                        uiTextTimer -= Time.deltaTime;
                    }




                    /*

                        ---- Zeug für Update

                    */
                }

                timerTxt.text = timeDis.ToString("0");

                    

        } else {
            startCountdown.text = timerStart.ToString("0");
            timerStart -= Time.deltaTime;
        }
        
    }


    public void setHardnessLvl(int hardnessValue){
       
    }

    public void finishMinigame(){
        mgmt.quizabcMinigameOver(score);
    }


    public void resetMg() {
        score = 0;
        scoreTxt.text = "0";
        setLoginType();
        timerStart = 1.0f;
        timeDis = 30f;

            

        startContainer.SetActive(true);
        //curImg = empty;
        this.gameObject.SetActive(false);

    }


    public void setLoginType(){
    
        int t = Random.Range(0,3);
        
    }


       

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }


}