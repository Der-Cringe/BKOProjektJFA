using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class quizGameabc : MonoBehaviour
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


    public GameObject questionText;
    
    public GameObject textAnswerA;
    public GameObject textAnswerB;
    public GameObject textAnswerC;
    private string currentQuestion;
    private string answerA;
    private string answerB;
    private string answerC;
    private int rightAnswer;
    public string[] questionsList;
    public float timerForNextQ;
    public bool questionenAnswered;
    private ColorBlock originalColorBlock;
    private ColorBlock pressedColorBlockGreen;
    private ColorBlock pressedColorBlockRed;


    void Start()
    {
        originalColorBlock = textAnswerA.GetComponent<Button>().colors;
        pressedColorBlockRed = ColorBlock.defaultColorBlock;
        pressedColorBlockRed.disabledColor = Color.red;
        pressedColorBlockGreen = ColorBlock.defaultColorBlock;
        pressedColorBlockGreen.disabledColor = Color.green;
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

                if(timeDis < 0.0f) {
                    finishMinigame();
                    resetMg();
                }
                else{
                    timeDis -= Time.deltaTime;
                    /*

                        ---- Zeug für Update

                    */


                    //Text Timer für oben
                    if(timerForNextQ < 0.0f) {
                        if(questionenAnswered == true){
                            questionenAnswered = false;
                            nextQuestion();
                        }
                    } 
                    else 
                    {
                        timerForNextQ -= Time.deltaTime;
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
        timerForNextQ = 0;
        scoreTxt.text = "0";
        string readFromFilePath = Application.streamingAssetsPath + "/Text/"  + "quizGametxt"  + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        questionsList = fileLines.ToArray();
        nextQuestion();
        timerStart = 1.0f;
        timeDis = 30f;

            

        startContainer.SetActive(true);
        //curImg = empty;
        //this.gameObject.SetActive(false);

    }


    public void nextQuestion(){
        setAllActivationButton(true);
        unMarkAllAnswers();
        questionenAnswered = false;
        int t = Random.Range(0,questionsList.Length);
        string[] questionValues = questionsList[t].Split(';');
        currentQuestion = questionValues[0];
        int[] leftAnswers = new int[] { 1, 2, 3 };
        int chosenOne;
        // Erste
            chosenOne = Random.Range(0,3);
            setRightAnswer(leftAnswers[chosenOne],1);
            answerA = questionValues[leftAnswers[chosenOne]];
            leftAnswers = leftAnswers.Where(val => val != leftAnswers[chosenOne]).ToArray();
        // Erste
        // Zweite
            chosenOne = Random.Range(0,2);
            setRightAnswer(leftAnswers[chosenOne],2);
            answerB = questionValues[leftAnswers[chosenOne]];
            leftAnswers = leftAnswers.Where(val => val != leftAnswers[chosenOne]).ToArray();
        // Zweite
        // Dritte
            setRightAnswer(leftAnswers[0],3);
            answerC = questionValues[leftAnswers[0]];
        // Dritte
        setTextIntoUI();
    }


 

    public void anwerChosen(int chosenOne){
        Debug.Log("WhatChosen: "+ chosenOne + ", Right Anwser: " + rightAnswer);
        if(chosenOne == rightAnswer){
            score += 70;
            scoreTxt.text = score.ToString();
            setAllActivationButton(false);
            markAnswer(chosenOne,true);
        }
        else{
            score -= 35;
            if(score < 0){
                score = 0;
            }
            scoreTxt.text = score.ToString();
            setAllActivationButton(false);
            markAnswer(chosenOne,false);
        }
        timerForNextQ = 2f;
        questionenAnswered = true;

    }


    public void setAllActivationButton(bool aktive){
        textAnswerA.GetComponent<Button>().interactable = aktive;
        textAnswerB.GetComponent<Button>().interactable = aktive;
        textAnswerC.GetComponent<Button>().interactable = aktive;
    }



    public void setRightAnswer(int value,int answer){
        if(value == 1){
            rightAnswer = answer;
        }
    }
       

    public void writetoUI(string ptext, float waittime){
        uiTextTimer = waittime;
        infoText.text = ptext;
    }

    public void setTextIntoUI(){
        questionText.GetComponent<Text>().text = currentQuestion;
        textAnswerA.GetComponent<Text>().text = "A) " + answerA;
        textAnswerB.GetComponent<Text>().text = "B) " + answerB;
        textAnswerC.GetComponent<Text>().text = "C) " + answerC;
    }

    public void unMarkAllAnswers(){
        ColorBlock a = textAnswerA.GetComponent<Button>().colors = originalColorBlock;
        ColorBlock b = textAnswerB.GetComponent<Button>().colors = originalColorBlock;
        ColorBlock c = textAnswerC.GetComponent<Button>().colors = originalColorBlock;
    }

    public void markAnswer(int chosenOne,bool boolean){
        ColorBlock marker;
        if(boolean == true){
            marker = pressedColorBlockGreen;
        }
        else{
            marker = pressedColorBlockRed;
        }
        if(chosenOne == 1){
            ColorBlock a = textAnswerA.GetComponent<Button>().colors =  marker;
        }
        else{
            if(chosenOne == 2){
                ColorBlock b = textAnswerB.GetComponent<Button>().colors = marker;
            }
            else{
                if(chosenOne == 3){
                    ColorBlock c = textAnswerC.GetComponent<Button>().colors  = marker;
                }
                else{
                    Debug.Log("Error WTF HAPPEND noChosen?");
                }
            }
        }
    }

}