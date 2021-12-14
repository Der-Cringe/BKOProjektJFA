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
    public GameObject empty;
    private GameObject curImg;


    public Manager mgmt;

    public Text timerTxt;
    public Text scoreText;

    public GameObject startContainer;
    public Text startCountdown;

    public float nextPictureTimer = 1.0f;

    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer
        if(timerStart < 0.0f) {
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
                    timeDis = nextPictureTimer;
                    clicked = false;
<<<<<<< HEAD
                    do{
                    rn = Random.Range(0,imgs.Length);
                    }
                    while(imgs[rn] == curImg);
                    
=======
                    rn = Random.Range(0,imgs.Length);
>>>>>>> db153e21b427c442fea6412e26b63a835767add6
                    curImg.SetActive(false);
                    imgs[rn].SetActive(true);
                    curImg = imgs[rn];
                    

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

    public void setHardnessLvl(int hardnessValue){
        nextPictureTimer -= nextPictureTimer* (hardnessValue /10);
    }

    public void pressInfo(int num) {
        if(clicked == false) {

            Debug.Log(num);
            Debug.Log(rn);
            if(rn == num) {
                score += 10;
            }
            clicked = true;
        } else {
        }

    }

    public void resetMg() {
        clicked = false;
        score = 0;
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
