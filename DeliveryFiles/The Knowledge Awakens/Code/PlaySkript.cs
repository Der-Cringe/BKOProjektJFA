using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySkript : MonoBehaviour
{

    public GameObject start;
    public GameObject options;
    public GameObject stats;
    public Text gamesplayed;
    public Text timeplayed;
    public Text highscore;
    public Text lastgame;
    public Text doorsopened;
    public Text quizplayed;
    public Text windowsopened;
    public Text osireactplayed;
    public Text eingeloged;
    public Text obstaclesdone;
    public Text monitorsteck;
    public Text minigamesplayed;
    public void Play() {
        SceneManager.LoadScene("tutorialScene");
    }

    public void Options(){
        start.SetActive(false);
        options.SetActive(true);
    }

    public void Stats(){
        setStats();
        options.SetActive(false);
        stats.SetActive(true);
    }

    public void backtoOptions(){
        options.SetActive(true);
        stats.SetActive(false);
    }
    

    public void backToStart(){
        start.SetActive(true);
        options.SetActive(false);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Start() {
        options.SetActive(false);
    }


    public void setStats(){

        PlayerPrefs.SetInt("obstaclesdone",PlayerPrefs.GetInt("doorsopened",0) + PlayerPrefs.GetInt("windowsopened",0) + PlayerPrefs.GetInt("eingeloged",0) + PlayerPrefs.GetInt("monitorsteck",0));
        PlayerPrefs.SetInt("minigamesplayed",PlayerPrefs.GetInt("quizplayed",0) + PlayerPrefs.GetInt("osireactplayed",0));

        gamesplayed.text        = PlayerPrefs.GetInt("gamesplayed",0).ToString();

        timeplayed.text         = PlayerPrefs.GetInt("timeplayed",0).ToString() + "min";
        highscore.text          = PlayerPrefs.GetInt("highscore",0).ToString()+"%";
        lastgame.text           = PlayerPrefs.GetInt("lastgame",0).ToString()+"%";
        
        quizplayed.text         = PlayerPrefs.GetInt("quizplayed",0).ToString();
        osireactplayed.text     = PlayerPrefs.GetInt("osireactplayed",0).ToString();
        
        doorsopened.text        = PlayerPrefs.GetInt("doorsopened",0).ToString();
        windowsopened.text      = PlayerPrefs.GetInt("windowsopened",0).ToString();
        eingeloged.text         = PlayerPrefs.GetInt("eingeloged",0).ToString();
        monitorsteck.text        = PlayerPrefs.GetInt("monitorsteck",0).ToString();
        
        obstaclesdone.text      = PlayerPrefs.GetInt("obstaclesdone",0).ToString();
        minigamesplayed.text    = PlayerPrefs.GetInt("minigamesplayed",0).ToString();
    }


}
