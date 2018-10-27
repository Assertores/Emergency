using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    Healthbar healthbar;
    GameManager gameManager;
    Animator PatientAnim;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();

	}
	
	void Update ()
    {
		
	}
    public void Die()
    {
        gameManager.RealeaseMoney(getMoney);

        //neuer patient
        //tod anim
        //
    }
    public void ResetPatient(float life, uint money)
    {
        getMoney = money;
        healthbar.SetMaxHealth(life);
    }
    public void DealDamage(float dmg)
    {
        healthbar.Decrease(dmg);
    }
}
