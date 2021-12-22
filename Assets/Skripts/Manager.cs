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

    // Audio sources
    

    ///<Variablen>
    ///     Player Objekt
    /// </Variablen>
    public GameObject Player;

    /// <Variablen>
    ///     Room Setups
    /// </Variablen>
    public Transform SpawnPointFloorPos;
    public Transform SpawnPointClassPos;
    public GameObject StudentsClass;
    public GameObject StudentsFloor;
    public GameObject goldenPc;
    public GameObject goldenLogin;
    public GameObject goldenPaper;
    public GameObject blueCable;
    public GameObject pauseWindow;
    public GameObject optionsWindow;


    /// <Variablen>
    ///     UI Abteile
    /// </Variablen>
    public GameObject AgainScreen;
    public GameObject fullInGameUi;

    /// <Variablen>
    ///     Ui Single Elemente
    /// </Variablen>
    private double VolumeValue;
    private int knowledgeValue;
    private double stinkyValue;

    public float windowClosedCooldown;

    public bool windowClosed;

    public bool logindone;


    public Slider DezibelSlider;
    public Slider knowledgeSlider;
    public Slider stinkySlider;
    public Slider focusSlider;
    public Text clockText;
    private int score;

    /// <Variablen>
    ///     Time
    /// </Variablen>
    private float day = 0.3128f;

    /// <Variablen>
    ///     Interakt Variablen 
    /// </Variablen>
    public bool[] interaktiv;
    public int InteraktId;

    /// <Variablen>
    ///     Minigame Verwaltung
    /// </Variablen>
    public GameObject[] mgs;
    public int currentMg;

    /// <Variablen>
    ///     NPC Variablen
    /// </Variablen>
    public GameObject[] talkingBubbles;
    public GameObject[] npcs;
    private double nextDezibelUp;
    private int randomNpcDezCount;    ///     Muss ist zukunft nicht Random sein

    //  Variablen
    //      Pc Plug
    //  Variablen

    public bool pcStuck;

    public bool pausedOpened;



    /// <summary>
    ///     Diese von unity vorgegebnen FUnktionen kümmern sich um den start und 
    ///     den durchlauf des games hier wird sich um folgendes gekürmmert
    ///     Start
    ///         reseten Wichtiger Variablen
    ///         setzten von Voreinstellung
    ///     Update
    ///         Setzten von Wichtigen Ui Elementen die dauer Aktuell sein müssen
    ///         
    /// </summary>
    private void Start() {
        //InteraktId = -1;
        pcStuck = false;
        logindone = false;
        pausedOpened = false;
        interaktiv = new bool[20];
        blueCable.SetActive(false);
        goldenPaper.SetActive(false);
        pauseWindow.SetActive(false);
        optionsWindow.SetActive(false);
        InteraktId = -1;
        knowledgeValue = 0;
        setknowledgeSlider();
        VolumeValue         = 650;
        setDezibelSlider();
        stinkyValue         = 650;
        windowClosed        = true;
        windowClosedCooldown = 0;
        setStinkySlider();
        setFocusSlider();
        nextDezibelUp       = 0;
        randomNpcDezCount   = 0;
        SpawnPlayer();
        StudentsClass.SetActive(false);
        StudentsFloor.SetActive(true);
        start_deaktiv_UI();
        
        
    
    }
    private void Update() {

        for(int i = 0;i < interaktiv.Length-1;i++) {
            if(interaktiv[i] == true && i != 5) {
                InteraktId = i;
            }
            else{
                if(interaktiv[5] == true && logindone == false){
                    InteraktId = 5;
                }
            }
        }

        if(VolumeValue > DezibelSlider.maxValue) {
            VolumeValue = DezibelSlider.maxValue;
        }else if(VolumeValue < 0) {
            VolumeValue = 0;
        }


        if(stinkyValue > stinkySlider.maxValue) {
            stinkyValue = stinkySlider.maxValue;
        }else if(stinkyValue < 0) {
            stinkyValue = 0;
        }

        if(windowClosedCooldown <= 0){
            //Debug.Log("DaBinich" + ((int)(Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY) * 80000));
            windowClosed = true;
            stinkyValue += ((Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY) * 8000);
        }
        else{
            windowClosedCooldown -= Time.deltaTime;
        }

        VolumeValue += ((Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY) * 8000);



        setDezibelSlider();
        setStinkySlider();
        setFocusSlider();
        setknowledgeSlider();
        setTime();

        // if(nextDezibelUp < 0.0f) {
        //     nextDezibelUp = Random.Range(1,8);
        //     randomNpcDezCount = Random.Range(2,6);
        //     makeNoises(randomNpcDezCount);
        // } else {
        //     nextDezibelUp -= Time.deltaTime;
        // }

        
    }

    /// <summary>
    ///     Die folgenden Funktionen kümmern sich um das vorsetup/setup/übergänge welchen auch in Start benutzt wird
    ///         SpawnPlayer : Spawnt Player im Flur
    ///         startDoor   : Leitet player weiter zum Raum 
    ///         
    /// </summary>
    private void SpawnPlayer()
    {
        Player.transform.position = SpawnPointFloorPos.position;
    }
    private void movetoClass() {
        Player.transform.position = SpawnPointClassPos.position;
        StudentsClass.SetActive(true);
        StudentsFloor.SetActive(false);
    }


    /// <summary>
    /// Die Folgenden Funktionen sind die Minigame verwaltungen 
    ///     doorMinigame    :   zeigt das doorMinigame an
    ///         
    /// </summary>
    /// 
    public void doorMinigame() {
        fullInGameUi.SetActive(false);
        interaktiv[InteraktId] = false;
        mgs[0].SetActive(true);
    }
    public void doorMinigameOver() {
        mgs[0].SetActive(false);
        movetoClass();
        fullInGameUi.SetActive(true);
    }

    public void quizabcMinigame() {
        fullInGameUi.SetActive(false);
        interaktiv[InteraktId] = false;
        mgs[3].SetActive(true);
        

    }

    public void windowMinigame() {
        fullInGameUi.SetActive(false);
        mgs[4].SetActive(true);
    }

    public void loginMinigame() {
        fullInGameUi.SetActive(false);
        interaktiv[InteraktId] = false;
        mgs[5].SetActive(true);
    }

    public void startQuest(int i) {
        if(i == 1) {
            minigame_1();
        }else if(i == 2) {
            minigame_2();
        } 
    }
    private void minigame_1() {
        fullInGameUi.SetActive(false);
        mgs[1].GetComponent<stdSettingMgSkript>().setHardnessLvl((int)getFocus());
        mgs[1].SetActive(true);
    }
    private void minigame_2() {
        fullInGameUi.SetActive(false);
        mgs[2].SetActive(true);
    }
    public void pcStuckEnd()
    {
        pcStuck = true;
        mgs[2].SetActive(false);
        fullInGameUi.SetActive(true);
        interaktiv[InteraktId] = false;
    }
    public void sendResultsToMgmt(int uscore) {
        mgs[currentMg].SetActive(false);
        fullInGameUi.SetActive(true);
        // Setztung des Knowledge Wert aufbasis der Resultate des minigames
        knowledgeValue = knowledgeValue + uscore / 10;
        interaktiv[InteraktId] = false;


    }
    public void windowMinigameOver(){
        mgs[4].SetActive(false);
        fullInGameUi.SetActive(true);
        stinkyValue = 0;
        windowClosedCooldown = 30;
        windowClosed = false;
    }

    public void loginMinigameOver(){
        logindone = true;
        mgs[5].SetActive(false);
        fullInGameUi.SetActive(true);
    }



     public void quizabcMinigameOver(int score){
        mgs[3].SetActive(false);
        knowledgeValue = knowledgeValue + score / 10;
        fullInGameUi.SetActive(true);
    }


    /// <summary>
    ///     Volume Manipulation
    /// </summary>
    public void setVolumeValue(int newVal) {
        VolumeValue = newVal;
    }
    public void AddVolumeValue(int newVal) {
        VolumeValue += newVal;
    }
    public void removeVolumeValue(int newVal) {
        VolumeValue -= newVal;
    }
    public double getVolumeValue() {
        return VolumeValue;
    }
    void setDezibelSlider() {
        DezibelSlider.value = (float)VolumeValue;
    }

    void setFocusSlider() {
        focusSlider.value = 100 - (((float)VolumeValue / 10) / 2 + ((float)stinkyValue / 10) / 2);
    }
    private float getFocus()
    {
        return 100 - (((float)VolumeValue / 10) / 2 + ((float)stinkyValue / 10) / 2);
    }

    void setStinkySlider() {
        stinkySlider.value = (float)stinkyValue;
    }

    /// <summary>
    ///    Interaktiv Verwaltung 
    /// </summary>
    public void interaktivSet(bool a,int id) {
            interaktiv[id] = a;
    }


    /// <summary>
    ///     Zeit Funktionen
    ///         setTime : Schulzeitverwaltung
    ///         gameTimeEnd : wenn die Zeit um ist 
    /// </summary>
    public void setTime() {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;
        float hoursPerDay = 24f;

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        clockText.text = hoursString + ":" + minutesString;

        // Wenn die Zeit 14:30 beträgt wird eine methode aufgerufen da dies das Ende des Unterrichts ist!
        if(day >= 0.6027f) {
            gameTimeEnd();
        }
    }
    public void gameTimeEnd() {
        day = 0.3128f;
        score = knowledgeValue;
        AgainScreen.SetActive(true);
    }


    /// <summary>
    ///     NPC Funktionen   
    /// </summary>
    // private void makeNoises(int count) {
    //     for(int i = 0 ; i < count;i++ ) {
    //         NPCskript tmpSkript = npcs[Random.Range(0,npcs.Length - 1)].GetComponent<NPCskript>();
    //         if(tmpSkript.picked == false) {
    //             tmpSkript.picked = true;
    //             AddVolumeValue(Random.Range(0,6));
    //             tmpSkript.talk(talkingBubbles[Random.Range(0,talkingBubbles.Length-1)]);
    //         }
    //     }
    // }
  
    
    /// <summary>
    ///     UI Funktionen
    /// </summary>
    public void setknowledgeSlider(){
        knowledgeSlider.value = knowledgeValue;
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
    private void start_deaktiv_UI() {
        for(int i = 0;i < mgs.Length;i++) {
            mgs[i].SetActive(false);
        }
        
    }
    /// <summary>
    /// Scenen Management Funktionen
    /// </summary>
    public void restart_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void resume() {
        pausedOpened = false;
        pauseWindow.SetActive(false);
        optionsWindow.SetActive(false);
        Time.timeScale = 1f; // normal ist 1f
    }

    public void Options(){
        pauseWindow.SetActive(false);
        optionsWindow.SetActive(true);
    }

    public void backToStart(){
        pauseWindow.SetActive(true);
        optionsWindow.SetActive(false);
    }

    public void pauseGame(){
        if(!pausedOpened){
        pausedOpened = true;
        pauseWindow.SetActive(true);
        Time.timeScale = 0f;
        }
    }

    public void Quit(){
        Application.Quit();
    }



}
