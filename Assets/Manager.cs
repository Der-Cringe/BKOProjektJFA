using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager:MonoBehaviour {


    //  Private Section
    //  Value that Contains the curretn Dezibel Value
    //  We use this to Controll the dezibel Slider
    private int VolumeValue;
    public Slider DezibelSlider;
    
    private bool interaktiv;
    public GameObject interaktivObj;

    private void Start() {
        VolumeValue = 20;
    }
    private void Update() {
        if(VolumeValue > DezibelSlider.maxValue) {
            VolumeValue = (int)DezibelSlider.maxValue;
        } else if(VolumeValue < 0) {
            VolumeValue = 0;
        }
        setSlider();
    }


    void setSlider() {
        DezibelSlider.value = VolumeValue;
    }
    public void startQuest() {
        Debug.Log("HEHE");
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
    public void interaktivSet(bool a,GameObject b) {
        interaktiv = a;
        interaktivObj = b;
    }
    public bool GetInteraktiv() {
        return interaktiv;
    }
}
