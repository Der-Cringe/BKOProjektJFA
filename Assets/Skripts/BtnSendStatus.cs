using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSendStatus : MonoBehaviour
{
    public stdSettingMgSkript btnTarget;
    public int ID;
    public void send() {
        btnTarget.pressInfo(ID);
    }
}
