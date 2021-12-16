using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMinigameButton : MonoBehaviour
{
    public doorMinigameScript btnTarget;
    public int ID;
    public void openButtonMethod() {
        Debug.Log("hierButton");
        if(ID == 5){
            Debug.Log("hierButton5");
            btnTarget.useLockBtn();
        }
        if(ID == 6){
            Debug.Log("hierButton6");
            btnTarget.useHandleBtn();
        }
    }
}