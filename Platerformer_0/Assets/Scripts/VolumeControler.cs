using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControler : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public string mixerParameterName;   // Param BGM, SFX 작성해주는 공간
    public float sliderMultiPiler = 25;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0001f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderValue(float value)
    {
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultiPiler);
        Debug.Log(Mathf.Log10(value));
    }
}
