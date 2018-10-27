using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    Healthbar healthbar;
    GameManager gameManager;
    public Animator PatientAnim;
    PatientLoader patientLoader;

    Vector2 AnimationTarget;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();
        patientLoader = this.gameObject.GetComponent<PatientLoader>();
        //PatientAnim = this.gameObject.GetComponentInChildren<Animator>();
	}
	
	void Update ()
    {
	}

    public void Die()
    {
        gameManager.RealeaseMoney(getMoney);
        PatientAnim.SetBool("Die", true);
        patientLoader.RandomizePatient();
    }

    public void ResetPatient(float life, uint money)
    {
        getMoney = money;
        healthbar.SetMaxHealth(life);
        PatientAnim.SetBool("Die", false);
    }

    public void DealDamage(float dmg)
    {
        healthbar.Decrease(dmg);
    }

    private void OnMouseDown() {
        print("where trying this now");
        gameManager.MakeHit();
    }
}
