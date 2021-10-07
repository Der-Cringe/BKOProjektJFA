using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    
    
    //Private
    //  Value that Contains the curretn Dezibel Value
    //  We use this to Controll the dezibel Slider
    private int VolumeValue;
    public Slider DezibelSlider;


    private void Start() {
        VolumeValue = 20;
    }
    private void Update() {
        setSlider();
    }


    void setSlider() {
        DezibelSlider.value = VolumeValue;
    }

    // Attribut Controll Methods
    public void setVolumeValue(int newVal) {
        VolumeValue = newVal;
    }
    public int getVolumeValue() {
        return VolumeValue;
    }
}
