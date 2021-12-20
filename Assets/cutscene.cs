using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject liebberger;
    public GameObject[] spawnpoint;
    public Transform byeLine;
    public GameObject ausrufezeichen;

    public Text TalkText;
    float movespeed = -0.4f;
    private int txtStateID;
    private float txtspeedcountdown = 2.0f;
    private bool Stop = false;
    private bool stop_2;
    private bool stop_3;
    public GameObject black;
    private float timer = 1.0f; 
    private void Start() {
        black.SetActive(false);   
        txtStateID = 1;
    }
    public void Update() {

        if(txtStateID == 3) {
            Instantiate(ausrufezeichen,new Vector2(liebberger.transform.position.x + 1,liebberger.transform.position.y),Quaternion.identity);
            Stop = true;
            txtStateID++;
            TalkText.text = "Mist unterlagen vergessen, hier der NFC Chip Fritz, mach schonmal auf ja ?";
        }
        if(Stop == true) {

            if(liebberger.transform.position == spawnpoint[1].transform.position) {
                stop_2 = true;
                Destroy(ausrufezeichen.gameObject);
            } else if(liebberger.transform.position != spawnpoint[1].transform.position && stop_2 == false) {
                liebberger.transform.position = Vector2.MoveTowards(liebberger.transform.position,spawnpoint[1].transform.position,4 * Time.deltaTime);
                Debug.Log("L    : "+ liebberger.transform.position);
                Debug.Log("S    : " + spawnpoint[1].transform.position);

            }

            if(stop_2 == true) {
                liebberger.transform.position = Vector2.MoveTowards(liebberger.transform.position,spawnpoint[2].transform.position,4 * Time.deltaTime);
                stop_3 = true;
            }
            if(stop_3 == true) {
                black.SetActive(true);
                if(timer < 0.0f) {
                    SceneManager.LoadScene("main");
                } else {
                    timer -= Time.deltaTime;
                }
            }

        } else {
            transform.position = new Vector2(transform.position.x,transform.position.y + movespeed * Time.deltaTime);
        }
        switch(txtStateID) {
            case 1:
            TalkText.text = "Willkomen an unserer  Schule Fritz hoffentlich mundet es dir hier !!!!";
            break;
            case 2:
            TalkText.text = "Oh, davorne sind auch schon deine Kollegen";
            break;
        }

        if(txtspeedcountdown <= 0.0f) {

            txtspeedcountdown = 2.0f;
            txtStateID++;
      


            


        } else {
            txtspeedcountdown -= Time.deltaTime;
            
        }

    }
}
