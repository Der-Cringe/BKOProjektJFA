using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControll : MonoBehaviour
{

    [SerializeField] string volumeParameter ="MasterVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;
    [SerializeField] float multiplier = 30f;
    
    private void Awake(){
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }
    // Start is called before the first frame update

    private void HandleSliderValueChanged(float value){
        if(slider.value == 0){
            mixer.SetFloat(volumeParameter,-80);
        }
        else{
            mixer.SetFloat(volumeParameter,Mathf.Log10(value) * multiplier);
        }

    }

    private void OnDisable(){
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
