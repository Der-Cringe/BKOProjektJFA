using System.Collections;
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


    public GameObject[] talkingBubbles;
    public GameObject[] npcs;
    private double nextDezibelUp;
    private int randomNpcDezCount;


    private void Start() {
        VolumeValue         = 20;
        nextDezibelUp       = 0;
        randomNpcDezCount   = 0;
    }
    private void Update() {
        if(VolumeValue > DezibelSlider.maxValue) {
            VolumeValue = (int)DezibelSlider.maxValue;
        }else if(VolumeValue < 0) {
            VolumeValue = 0;
        }
        setSlider();
        setTime();

        if(nextDezibelUp < 0.0f) {
            nextDezibelUp = Random.Range(1,8);
            randomNpcDezCount = Random.Range(2,6);
            Debug.Log("tst UPDATE");
            makeNoises(randomNpcDezCount);
        } else {
            nextDezibelUp -= Time.deltaTime;
        }

        
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

        // Wenn die Zeit 14:30 beträgt wird eine methode aufgerufen da dies das Ende des Unterrichts ist!
        if(day >= 0.6027f){
            gameTimeEnd();
        }
    }

    public void gameTimeEnd(){
        day = 0.3128f;
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
    private void makeNoises(int count) {
        for(int i = 0 ; i < count;i++ ) {
            NPCskript tmpSkript = npcs[Random.Range(0,npcs.Length - 1)].GetComponent<NPCskript>();
            Debug.Log("tst FOR");
            if(tmpSkript.picked == false) {
                tmpSkript.picked = true;
                AddVolumeValue(Random.Range(0,6));
                tmpSkript.talk(talkingBubbles[Random.Range(0,talkingBubbles.Length-1)]);
            }
        }
    }

}
