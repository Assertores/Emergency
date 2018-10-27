using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    GameObject SliderGo;//gO vom Slider zum aktivieren
    Slider SoundSlider;
    Button SoundImage;

    void Start()
    {
        SoundSlider = this.gameObject.GetComponentInChildren<Slider>();
        SoundSlider.onValueChanged.AddListener(delegate { ValueChanged(); });
        SoundSlider.value = 1;
        SliderGo = SoundSlider.gameObject;
        SliderGo.SetActive(false); SoundImage = this.gameObject.GetComponent<Button>();
        SoundImage.onClick.AddListener(delegate { OpenSlider(); });
    }

    void Update ()
    {
    }

    public void ValueChanged()
    {
        AudioListener.volume = SoundSlider.value;
    }
    void OpenSlider()   //onClick slider sichtbar 
    {
        if(SliderGo.activeInHierarchy == true)
        {
            SliderGo.SetActive(false);
        }
        else
        {
            SliderGo.SetActive(true);
        }
    }

}
