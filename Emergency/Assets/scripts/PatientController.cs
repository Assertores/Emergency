using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    Healthbar healthbar;
    GameManager gameManager;
    Animator PatientAnim;
    PatientLoader patientLoader;

    GameObject ClickHit;
    Vector2 AnimationTarget;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();
        patientLoader = this.gameObject.GetComponent<PatientLoader>();
        ClickHit = GameObject.Find("clicker");
	}
	
	void Update ()
    {
		
	}
    public void Die()
    {
        gameManager.RealeaseMoney(getMoney);
        PatientAnim.SetBool("die", true);
        patientLoader.RandomizePatient();
    }
    public void ResetPatient(float life, uint money)
    {
        getMoney = money;
        healthbar.SetMaxHealth(life);
        PatientAnim.SetBool("die", false);
    }
    public void DealDamage(float dmg)
    {
        healthbar.Decrease(dmg);
    }
    public void PlayerHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if(hit.transform.gameObject == ClickHit)
                {
                    AnimationTarget = hit.point;
                    print("playAnim");
                }
            }
        }
    }
}
