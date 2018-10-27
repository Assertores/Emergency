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

    //GameObject ClickHit;
    Vector2 AnimationTarget;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();
        patientLoader = this.gameObject.GetComponent<PatientLoader>();
        //ClickHit = GameObject.Find("clicker");
	}
	
	void Update ()
    {
        //PlayerHit();
        //Input.mousePosition;
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) {
            /*if (PatientHit()) {
                print("hit 1");
                gameManager.MakeHit();
            }*/
        }
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
    /*public bool PatientHit() //prüft ob Patient getroffen wurde
    {
        print("start funktion");
        RaycastHit2D hit;
        Input.mousePosition;
        
        if(Physics2D.Raycast(ray, out hit))
        {
            print(hit.ToString());
            if(hit.transform.gameObject == ClickHit)
            {
                AnimationTarget = hit.point;
                print("playAnim");
                return true;
            }
        }
        print("i faild");
        return false;
        
        Vector3 mousePos;
        if (Input.GetMouseButton(0)) {
            mousePos = Input.mousePosition;
            mousePos.z = 1.5f;
            worldPos = camera.ScreenToWorldPoint(mousePos);
            Instantiate(blue, worldPos, Quaternion.identity);
        }
        
    }*/

    private void OnMouseDown() {
        print("where trying this now");
        gameManager.MakeHit();
    }
}
