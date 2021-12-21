using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pcPluger : MonoBehaviour{

    public Manager mgmt;
    public GameObject Target;
    public GameObject empty;

    public GameObject rechts;
    public GameObject links;
    public GameObject[] spawnpoint;
    private int id;

    public GameObject Kabel;
    public GameObject Kabel_transparent;
    public GameObject Kabel_new;

    public GameObject buchse_1;
    public GameObject buchse_2;
    private bool isDragging;

    private bool[] check;

    public double uiTextTimer;
    public Text infoText;
    void Start() {
        check = new bool[2];
        uiTextTimer = 2.0f;
        Target = empty; 
        check[0] = false;
        check[1] = false;
        Kabel_new.SetActive(false);
    }
    

    void Update() {
        if (check[0] == true && check[1] == true)
        {
            Kabel.SetActive(false);
            Kabel_transparent.SetActive(false);
            Kabel_new.SetActive(true);
            infoText.text = "Congrats";
            //Text Timer für oben
            if (uiTextTimer < 0.0f)
            {
                mgmt.pcStuckEnd();
            }
            else
            {
                uiTextTimer -= Time.deltaTime;
            }
        }
        else {
        if (Input.GetMouseButtonDown(0)) {
            if(isDragging == true) {
                Kabel.SetActive(true);
                Kabel_transparent.SetActive(false);
                isDragging = false;
                Vector3 mousePos = Input.mousePosition;
                /*
                 Debug.Log("Rx    :   " + rechts.transform.position.x);
                 Debug.Log("Bx    :   " + buchse_1.transform.position.x);
                 Debug.Log("Ry    :   " + rechts.transform.position.y);
                 Debug.Log("By    :   " + buchse_1.transform.position.y);
                */
                Debug.Log(id);
               if(id == 0)
                {
                    if (links.transform.position.x <= buchse_2.transform.position.x + 30 && links.transform.position.x >= buchse_2.transform.position.x - 30)
                    {
                        if (links.transform.position.y <= buchse_2.transform.position.y + 30 && links.transform.position.y >= buchse_2.transform.position.y - 30)
                        {
                            Debug.Log("JOSEF STINKT SO MIES NACH KACKE Links");
                            check[1] = true;
                        }
                    }
                }
                else if(id == 1)
                {
                    if (rechts.transform.position.x <= buchse_1.transform.position.x + 30 && rechts.transform.position.x >= buchse_1.transform.position.x - 30)
                    {
                        if (rechts.transform.position.y <= buchse_1.transform.position.y + 30 && rechts.transform.position.y >= buchse_1.transform.position.y - 30)
                        {
                        Debug.Log("JOSEF STINKT SO MIES NACH KACKE Rechts");
                            check[0] = true;
                        }
                    }
                }
                else
                {
                    Debug.Log("Diggah Was ?");
                }

            } else if(isDragging == false) {
                Kabel.SetActive(false);
                Kabel_transparent.SetActive(true);
                isDragging = true;
                Target = empty;

            }

        }
        if(isDragging) {
            Vector3 mousePos = Input.mousePosition;
            Target.transform.position = new Vector3(0,0,0);
            Target.transform.position = mousePos;
                
        }
        }

        
        
    }
    public void change_target_to_left() {
        
        Target = links;
        id = 0;
    }
    public void change_target_to_right() {
        Target = rechts;
        id = 1;
    }
    public void writetoUI(string ptext, float waittime)
    {
        uiTextTimer = waittime;
        infoText.text = ptext;
    }
}
