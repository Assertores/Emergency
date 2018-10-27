using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    Healthbar healthbar;

    void Start ()
    {
        healthbar = GetComponent<Healthbar>();
	}
	
	void Update ()
    {
		
	}
    public void Die()
    {
        //geld ausschütten
        //neuer patient
        //tod anim
        //
    }
    public void ResetPatient(float life, uint money)
    {
        getMoney = money;
        healthbar.SetMaxHealth(life);
    }
}
