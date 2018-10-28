using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    Slider SoundSlider;
    Button SoundImage;
    AudioSource PlayClickSound;
    [SerializeField] AudioSource ButtonSource;
    [SerializeField] AudioSource DeseaseSound;

    void Start()
    {
        PlayClickSound = this.gameObject.GetComponent<AudioSource>();
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
        PlayClickSound.Play();
    }
    public void ButtonSound()
    {
        ButtonSource.Play();
    }
    public void Desease()
    {
        DeseaseSound.Play();
    }
}
