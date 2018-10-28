using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    GameManager gameManager;
    public Animator PatientAnim;
    Vector2 AnimationTarget;
    PatientLoader patientLoader;
    Healthbar healthbar;
    [SerializeField] GameObject Partikle;

    void Start()
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
        print(healthbar);
        healthbar.SetMaxHealth(life);
        PatientAnim.SetBool("Die", false);
    }

    public void DealDamage(float dmg)
    {
        healthbar.Decrease(dmg);
    }

    private void OnMouseDown()
    {
        gameManager.MakeHit();
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Partikle.transform.position = new Vector3(temp.x, temp.y, -1);

        print("POS:" + Partikle.transform.position.ToString());
        Partikle.GetComponent<ParticleSystem>().Play();
        //Partiel abfeuern
    }
}
