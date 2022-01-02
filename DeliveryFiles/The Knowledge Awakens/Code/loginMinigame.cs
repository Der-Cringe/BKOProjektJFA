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

    private string nameValue;
    public Text vornameTxt;
    public Text nachnameTxt;
    public Text passwortTxt;

    public string[] vornameOptions;
    public string[] nachnameOptions;
    public string[] passwortTeile;

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
            if(correctData == true){
                finishMinigame();
            }
        } else {
            uiTextTimer -= Time.deltaTime;
        }
    }


    public void setHardnessLvl(int hardnessValue){
       
    }

    public void finishMinigame(){
        mgmt.loginMinigameOver();
        resetMg();
    }


    public void resetMg() {
        score = 0;
        correctData = false;
        setNewLogins();
        for(int i = 0;i <= scenen.Length - 1;i++) {
            scenen[i].SetActive(false);
        }
        curSceneID = Random.Range(0,3);
        scenen[curSceneID].SetActive(true);
        setLoginType();
        valuesToUI();


        //this.gameObject.SetActive(false);

    }


    public void setNewLogins(){
        int vornameRandomID = Random.Range(0,15);
        int nachnameRandomID = Random.Range(0,5);
        int pwRandomID1 = Random.Range(0,8);
        int pwRandomID2 = Random.Range(0,8);
        int pwRandomID3 = Random.Range(0,8);
        int pwRandomID4 = Random.Range(0,8);

        vornameValue  = vornameOptions[vornameRandomID];
        nachnameValue = nachnameOptions[nachnameRandomID];
        passwortValue = passwortTeile[pwRandomID1] + passwortTeile[pwRandomID2] + passwortTeile[pwRandomID3] + passwortTeile[pwRandomID4];
    }


    public void sumitBtn(){
        string inputName = userNameInput.GetComponent<InputField>().text;
        string inputPW = passwortInput.GetComponent<InputField>().text;
        
        
        if(inputName != null && inputName != "" && inputPW != null && inputPW != ""){
            Debug.Log("|" + inputName + "|" + rightUsername + "|" + inputPW + "|" + passwortValue + "|");
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