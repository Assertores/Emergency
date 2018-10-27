using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PatientController patientController;
    [SerializeField] Player player;

	void Start ()
    {
        if (!patientController)
        {
            print("your an idiot");
        }
    }
	
	void Update ()
    {
		
	}
    public void DealDamage(float dmg)
    {
        patientController.DealDamage(dmg);
    }
    public void RealeaseMoney(uint amount)
    {
        player.AddMoney(amount);
    }
    public bool Buy(uint amount)
    {
        return player.Buy(amount);
    }
    public uint GetCurrentMoney() {
        return player.GetMoney();
    }
    public float GetCurrentDPC() {
        return player.GetDPC();
    }
    public void MakeHit() {
        print("hit 2");
        player.MakeHit();
    }
}