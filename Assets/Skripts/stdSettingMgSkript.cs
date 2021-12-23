using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class stdSettingMgSkript : MonoBehaviour
{
    //zeit in sec
    //Start Timer
    private double timerStart;
    //Generall Time
    public double timeMg;
    private double timer;
    //Objekt disappear Time    
    private double timeDis = 0.0f;

    int rn;
    bool clicked;

    private int score;
    public GameObject[] imgs;
    public int[] ids;
    public GameObject empty;
    private GameObject curImg;


    public Manager mgmt;

    public Text timerTxt;
    public Text scoreText;

    public GameObject startContainer;
    public Text startCountdown;

    public float nextPictureTimer = 1.0f;
    public float textTimer;
    public Text textForTimer;

    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer
        if(timerStart < 0.0f) {
            if(textTimer < 0.0f){
                
            }
            else {
                textTimer -= Time.deltaTime;
            }
            startContainer.SetActive(false);
            timerTxt.text = timer.ToString("00");
            //GameTimer
            if(timer < 0.0f) {
                //Debug.Log("Test Szenario");
                mgmt.sendResultsToMgmt(score);
                resetMg();
            } else {
                timer -= Time.deltaTime;
                //PictureTimer
                if(timeDis < 0.0f) {
                    nextPicture();
                } else {
                    timeDis -= Time.deltaTime;
                }
            }
        } else {
            startCountdown.text = timerStart.ToString("0");
            timerStart -= Time.deltaTime;
        }
        scoreText.text = score.ToString("0");
    }

    public void nextPicture(){
        Debug.Log(nextPictureTimer);
                    timeDis = nextPictureTimer;
                    clicked = false;
                    do{
                    rn = Random.Range(0,imgs.Length);
                    }
                    while(imgs[rn] == curImg);

                    curImg.SetActive(false);
                    imgs[rn].SetActive(true);
                    curImg = imgs[rn];
    }

    public void setHardnessLvl(int hardnessValue){

        nextPictureTimer = hardnessValue  / 10  ;
        if(nextPictureTimer > 5)
        {
            nextPictureTimer = 5;
        }
        if(nextPictureTimer <= 0){
            nextPictureTimer = 1;
        }
        Debug.Log(hardnessValue);
    }

    public void pressInfo(int num) {
        if(clicked == false) {
            if(ids[rn] == num) {
                score += 30;
                textForTimer.text = "Right!";
                textTimer = 0.25f;
                timeDis = 0;
            }
            else{
                score -= 60;
                textForTimer.text = "Wrong!";
                textTimer = 0.25f;
                timeDis = 0;
            }

            if(score < 0){
                score = 0;
            }

            clicked = true;
        } else {
        }

    }

    public void resetMg() {
        clicked = false;
        score = 0;
        textForTimer.text = "";
        startContainer.SetActive(true);
        timerStart = 3.0f;
        curImg = empty;
        timer = timeMg;
        timeDis = 0.0f;
        this.gameObject.SetActive(false);

        for(int i = 0; i < imgs.Length;i++) {
            imgs[i].SetActive(false);
        }
    }


}
