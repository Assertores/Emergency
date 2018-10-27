using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[RequireComponent(typeof(PatientController))]
public class Healthbar : MonoBehaviour
{
    float MaxHealth = 10f;
    float currentLife;
    Image Lifebar;

    public GameObject gameManager;

	void Start ()
    {
        Lifebar = this.gameObject.GetComponent<Image>(); 
        Lifebar.fillAmount = 1;
    }

    void Update ()
    {
		
	}

    public void SetMaxHealth(float temp)
    {
        MaxHealth = temp;
    }

    public void Decrease(float damage)
    {
        currentLife -= damage;
        if(currentLife <= 0)
        {
            //tod an patientController
        }
    }
}
