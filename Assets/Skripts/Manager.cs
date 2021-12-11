﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager:MonoBehaviour {


    //  Private Section
    //  Value that Contains the curretn Dezibel Value
    //  We use this to Controll the dezibel Slider
    private const float REAL_SECONDS_PER_INGAME_DAY = 600f;

    private int VolumeValue;
    private float day = 0.3128f;

    public Slider DezibelSlider;
    public Text clockText;

    private bool interaktiv;
    //public GameObject interaktivObj;
    public GameObject fullInGameUi;


    public GameObject[] mgs;
    public int currentMg;



    private void Start() {
        VolumeValue = 20;
    }
    private void Update() {
        if(VolumeValue > DezibelSlider.maxValue) {
            VolumeValue = (int)DezibelSlider.maxValue;
        }else if(VolumeValue < 0) {
            VolumeValue = 0;
        }
        setSlider();
        setTime();
    }

    void setSlider() {
        DezibelSlider.value = VolumeValue;
    }

    // Attribut Controll Methods
    public void setVolumeValue(int newVal) {
        VolumeValue = newVal;
    }
    public void AddVolumeValue(int newVal) {
        VolumeValue += newVal;
    }
    public void removeVolumeValue(int newVal) {
        VolumeValue -= newVal;
    }
    public int getVolumeValue() {
        return VolumeValue;
    }

    public void setTime(){
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        //Debug.Log("Time: "+ day);

        float dayNormalized = day % 1f;
        float hoursPerDay = 24f;
        
        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized* hoursPerDay) % 1f) * minutesPerHour).ToString("00");
        
        clockText.text = hoursString + ":" +minutesString;
    }
    public void interaktivSet(bool a,GameObject b) {
        interaktiv = a;
      //  interaktivObj = b;
    }
    public bool GetInteraktiv() {
        return interaktiv;
    }
    public void startQuest() {
        minigame();
        
    }
    // NPC AKTIONS
    public void goToTeacherTable() {

    }
    // Mini Games
    private void minigame() {
        fullInGameUi.SetActive(false);
        //random pic
        currentMg = Random.Range(0,mgs.Length-1);
        mgs[currentMg].SetActive(true);
    }
    public void sendResultsToMgmt(int uscore,stdSettingMgSkript ustd) {
        mgs[currentMg].SetActive(false);
        ustd.resetMg();

    }

}
