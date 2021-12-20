using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class loginMinigame : MonoBehaviour
{

    private int score;

    public GameObject userNameInput;
    public GameObject passwortInput;
    public string vornameValue;
    public string nachnameValue;
    public string passwortValue;

    private Text nameTxt;
    private Text vornameTxt;
    private Text nachnameTxt;
    private Text passwortTxt;

    private string rightUsername;
    private string rightPassword;

    private bool correctData;
    public Manager mgmt;



    /// <summary>
    /// Felix Programm New
    /// </summary>

    public GameObject[] scenen;
    private int curSceneID;
    private double uiTextTimer;
    public Text infoText;

    void Start()
    {
        resetMg();
    }
    private void Update() {
       if(uiTextTimer < 0.0f) {
            infoText.text = "";
        } else {
            uiTextTimer -= Time.deltaTime;
        }
    }


    public void Start_mg_pc_login() {
        curSceneID = Random.Range(0,2);
        scenen[curSceneID].SetActive(true);
        setLoginType();
        
    }

    public void setHardnessLvl(int hardnessValue){
       
    }

    public void finishMinigame(){
        mgmt.quizabcMinigameOver(score);
    }


    public void resetMg() {
        score = 0;
        correctData = false;
        setLoginType();
        //valuesToUI();

        for(int i = 0;i < scenen.Length - 1;i++) {
            scenen[i].SetActive(false);
        }

        this.gameObject.SetActive(false);

    }


    public void sumitBtn(){
        string inputName = userNameInput.GetComponent<InputField>().text;
        string inputPW = userNameInput.GetComponent<InputField>().text;
        


        if(inputName == rightUsername) {
            if(inputPW == rightPassword) {
                Debug.Log("Yes");
                writetoUI("Richtig!",2f);
                correctData = true;
            } else {
                writetoUI("Fehler!",1f);
            }
        } else {
            writetoUI("Fehler!",1f);
        }

        /*
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
    
        */
        }


    public void setLoginType(){
        // 0 = Moddle   Nachname.Vorname
        // 1 = Iserv    Vorname.Nachname
        // 2 = Window   Vorname.Nachname
        switch(curSceneID){
            case 0:
                rightUsername = nachnameValue + "." + vornameValue;
            break;
            case 1:
                rightUsername = vornameValue + "." + nachnameValue;
            break;
            case 2:
                rightUsername = vornameValue + "." + nachnameValue;
            break;
            default:
                Debug.Log("What the fuckl happend");
            break;

        }
    }


    /*
    public void valuesToUI(){
        vornameTxt.text = vornameValue;
        nachnameTxt.text = nachnameValue;
        passwortTxt.text = passwortValue;
    }
      */  

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }


}