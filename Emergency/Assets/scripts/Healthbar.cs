using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[RequireComponent(typeof(PatientController))]
public class Healthbar : MonoBehaviour
{
    float MaxHealth;
    float currentLife;
    Image Lifebar;

    public GameObject bar;
    PatientController patientController;

	void Start ()
    {
        patientController = GetComponent<PatientController>();
        Lifebar = bar.gameObject.GetComponent<Image>(); 
        Lifebar.fillAmount = 1;
    }

    void Update ()
    {
		
	}

    public void SetMaxHealth(float temp)
    {
        MaxHealth = temp;
        currentLife = MaxHealth;
    }

    public void Decrease(float damage)
    {
        currentLife -= damage;
        if(currentLife <= 0)
        {
            patientController.Die();    //tod an patientController
        }
        else
        {
            //schadensindikator
        }
        Lifebar.fillAmount = currentLife / MaxHealth;
    }
}
