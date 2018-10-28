using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    Slider SoundSlider;
    Button SoundImage;

    void Start()
    {
        SoundSlider = this.gameObject.GetComponent<Slider>();
        SoundSlider.onValueChanged.AddListener(delegate { ValueChanged(); });
        SoundSlider.value = 1;
    }

    void Update ()
    {
    }

    public void ValueChanged()
    {
        AudioListener.volume = SoundSlider.value;
    }
}
