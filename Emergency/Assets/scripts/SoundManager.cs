using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    Slider SoundSlider;

	void Start ()
    {
        SoundSlider = this.gameObject.GetComponent<Slider>();
        AudioListener.volume = SoundSlider.value;
	}
	
	void Update ()
    {
		
	}
    public void OnValueChanged()
    {
        AudioListener.volume = SoundSlider.value;
    }
}
