using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] uint Money;
    [SerializeField] float DPC;
    [SerializeField] float DPCMultiplyer = 1;
    [SerializeField] Text MoneyDisplay;
    [SerializeField] Text DPCDisplay;
    [SerializeField] Text DPCUpdateDisplay;
    GameManager gameManager;
    float AddedDPC = 0;
    uint BuyAmount = 1;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        AddedDPC = DPC * DPCMultiplyer;
        DPCUpdateDisplay.text = AddedDPC.ToString();
    }

    public void AddMoney(uint amount) {
        Money += amount;
        UpdateMoneyDisplay();
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
        UpdateMoneyDisplay();
        return true;
    }

    public void MakeHit() {
        gameManager.DealDamage(DPC);
    }

    public void UpgradeClick() {
        for (uint i = 0; i < BuyAmount; i++) {
            DPC += AddedDPC;
            AddedDPC = DPC * DPCMultiplyer;
        }
        DPCDisplay.text = DPC.ToString();
        DPCUpdateDisplay.text = AddedDPC.ToString();
    }

    void UpdateMoneyDisplay() {
        MoneyDisplay.text = Money.ToString();
    }
}