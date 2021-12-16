using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager:MonoBehaviour {


    //  Private Section
    //  Value that Contains the curretn Dezibel Value
    //  We use this to Controll the dezibel Slider
    private const float REAL_SECONDS_PER_INGAME_DAY = 600f;

    public Transform SpawnPointFloorPos;
    public Transform SpawnPointClassPos;
    public GameObject Player;
    public GameObject StudentsClass;
    public GameObject StudentsFloor;


    public GameObject AgainScreen;
    private int VolumeValue;
    private int knowledgeValue;
    private float day = 0.3128f;

    public Slider DezibelSlider;

    public Slider knowledgeSlider;
    public Text clockText;

    private bool interaktiv;
    public GameObject interaktivObj;
    public GameObject fullInGameUi;
    public int InteraktId;


    public GameObject[] mgs;
    public int currentMg;


    public GameObject[] talkingBubbles;
    public GameObject[] npcs;
    private double nextDezibelUp;
    private int randomNpcDezCount;

    private int score;

    private void Start() {
        knowledgeValue = 0;
        setknowledgeSlider();
        VolumeValue         = 20;
        setDezibelSlider();
        nextDezibelUp       = 0;
        randomNpcDezCount   = 0;
        SpawnPlayer();
        StudentsClass.SetActive(false);
        StudentsFloor.SetActive(true);
    
    
    }
    private void Update() {
        if(VolumeValue > DezibelSlider.maxValue) {
            VolumeValue = (int)DezibelSlider.maxValue;
        }else if(VolumeValue < 0) {
            VolumeValue = 0;
        }
        setDezibelSlider();
        setknowledgeSlider();
        setTime();

        if(nextDezibelUp < 0.0f) {
            nextDezibelUp = Random.Range(1,8);
            randomNpcDezCount = Random.Range(2,6);
<<<<<<< HEAD
            //Debug.Log("tst UPDATE");
=======
>>>>>>> eb2c179c8de73a9828ab66b9306cceb04a4410df
            makeNoises(randomNpcDezCount);
        } else {
            nextDezibelUp -= Time.deltaTime;
        }

        
    }


    private void SpawnPlayer()
    {
        Player.transform.position = SpawnPointFloorPos.position;
    }






    void setDezibelSlider() {
        DezibelSlider.value = VolumeValue;
    }

    public void setknowledgeSlider(){
        knowledgeSlider.value = knowledgeValue;
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
        score = knowledgeValue;
        AgainScreen.SetActive(true);
    }
    public void interaktivSet(bool a,GameObject b,int id) {
        interaktiv = a;
        interaktivObj = b;
        InteraktId = id;
    }
    public bool GetInteraktiv() {
        return interaktiv;
    }
    public void startQuest() {
        doorMinigame();
        
    }
    // Mini Games
    private void minigame() {
        fullInGameUi.SetActive(false);
        //random pic
        currentMg = Random.Range(0,mgs.Length-1);
        mgs[0].GetComponent<stdSettingMgSkript>().setHardnessLvl(VolumeValue);
        mgs[0].SetActive(true);
    }

    private void doorMinigame() {
        fullInGameUi.SetActive(false);
        mgs[1].SetActive(true);
    }

    public void sendResultsToMgmt(int uscore) {
        mgs[currentMg].SetActive(false);
        fullInGameUi.SetActive(true);
        // Setztung des Knowledge Wert aufbasis der Resultate des minigames
        knowledgeValue = knowledgeValue + uscore /10;


    }
    private void makeNoises(int count) {
        for(int i = 0 ; i < count;i++ ) {
            NPCskript tmpSkript = npcs[Random.Range(0,npcs.Length - 1)].GetComponent<NPCskript>();
<<<<<<< HEAD
            //Debug.Log("tst FOR");
=======
>>>>>>> eb2c179c8de73a9828ab66b9306cceb04a4410df
            if(tmpSkript.picked == false) {
                tmpSkript.picked = true;
                AddVolumeValue(Random.Range(0,6));
                tmpSkript.talk(talkingBubbles[Random.Range(0,talkingBubbles.Length-1)]);
            }
        }
    }
    public int get_score()
    {
        return score;
    }
    public void add_score(int a)
    {
        score += a;
    }
    public void reset_score()
    {
        score = 0;
    }

    public void restart_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void startDoor()
    {
        Debug.Log("fuck");
        //door game
        changeToMainRoom();
    }
    public void changeToMainRoom()
    {
        Player.transform.position = SpawnPointClassPos.position;
        StudentsClass.SetActive(true);
        StudentsFloor.SetActive(false);
    }
}
