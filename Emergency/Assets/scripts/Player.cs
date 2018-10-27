using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] uint Money;
    [SerializeField] float DPC;
    GameManager gameManager;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void AddMoney(uint amount) {
        Money += amount;
    }

    public uint GetMoney() {
        return Money;
    }

    public float GetDPC() {
        return DPC;
    }

    public bool Buy(uint cost) {
        if (Money < cost)
            return false;
        Money -= cost;
        return true;
    }

    public void MakeHit() {
        print("hit3");
        gameManager.DealDamage(DPC);
    }
}