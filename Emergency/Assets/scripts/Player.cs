using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] uint Money;
    [SerializeField] uint DPC;
	
    public void AddMoney(uint amount) {
        Money += amount;
    }

    public bool Buy(uint cost) {
        if (Money < cost)
            return false;
        Money -= cost;
        return true;
    }

    public void MakeHit() {
        //deal Damage(DPC)
    }
}