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
    public string vornameValue;
    public string nachnameValue;
    public string passwortValue;

    public Text nameTxt;
    public Text vornameTxt;
    public Text nachnameTxt;
    public Text passwortTxt;

    private string rightUsername;

    private bool correctData;



    void Start()
    {
        resetMg();
    }
    private void Update() {
        //StartTimer

        if(timerStart < 0.0f) {
            //Warum wird das immer wieder ausgeführt
            startContainer.SetActive(false);

                
                /*

                    ---- Zeug für Update

                */
                if(uiTextTimer < 0.0f) {
                    if(infoText.text != ""){
                        infoText.text = "";
                    }
                    if(correctData == true){
                        finishMinigame();
                        resetMg();
                    }
                } 
                else 
                {
                    uiTextTimer -= Time.deltaTime;
                }




                /*

                    ---- Zeug für Update

                */
                

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
        correctData = false;
        setLoginType();
        timerStart = 1.0f;
        timeDis = 30f;
        valuesToUI();

            

        startContainer.SetActive(true);
        //curImg = empty;
        this.gameObject.SetActive(false);

    }


    public void sumitBtn(){
        string inputName = userNameInput.GetComponent<InputField>().text;
        string inputPW = userNameInput.GetComponent<InputField>().text;
        if(inputName != null && inputName != "" && inputPW != null && inputPW != ""){
            if(inputName == rightUsername && inputPW == passwortValue){
                writetoUI("Richtig!",2f);
                correctData = true;
            }
            else{
                writetoUI("Fehler!",1f);
            }
        }
        else{
            writetoUI("Fehler!",1f);
        }
    }


    public void setLoginType(){
    
        int t = Random.Range(0,3);
        // 0 = Moddle   Nachname.Vorname
        // 1 = Iserv    Vorname.Nachname
        // 2 = Window   Vorname.Nachname
        switch(t){
            case 0:
                rightUsername = nachnameValue + "." + vornameValue;
                buildMoodle();
            break;
            case 1:
                rightUsername = vornameValue + "." + nachnameValue;
                buildIserv();
            break;
            case 2:
                rightUsername = vornameValue + "." + nachnameValue;
                buildWindows();
            break;
            default:
            Debug.Log("What the fuckl happend");
            break;

        }
    }

    public void buildIserv(){
        nameTxt.text = "Iserv";
    }

    public void buildMoodle(){
        nameTxt.text = "Moodle";
    }
    
    public void buildWindows(){
        nameTxt.text = "Windows";
    }

    public void valuesToUI(){
        vornameTxt.text = vornameValue;
        nachnameTxt.text = nachnameValue;
        passwortTxt.text = passwortValue;
    }


       

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }


}