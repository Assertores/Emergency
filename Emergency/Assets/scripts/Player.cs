using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] uint Money;
    [SerializeField] float DPC;
    [SerializeField] float DPCMultiplyer = 1;
    [SerializeField] Text MoneyDisplay;//prottypDisplay
    [SerializeField] Text DPCDisplay;
    [SerializeField] Text DPCUpdateDisplay;

    [SerializeField] int AmountPerClick = 1;
    [SerializeField] int ClickAmountMultiplier;
    [SerializeField] int x; //für Levelerhöhung
    GameManager gameManager;
    float AddedDPC = 0;
    uint BuyAmount = 1;
    float AddedClickAmount;
    uint UpgradeCount=0;

    
    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        AddedDPC = DPC * DPCMultiplyer;
        DPCUpdateDisplay.text = AddedDPC.ToString();
        UpdateMoneyDisplay();
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
        Money += (uint)AmountPerClick;
        print(Money);
    }

    public void UpgradeClick() {
        UpgradeCount++;
        for (uint i = 0; i < BuyAmount; i++) {
            DPC += AddedDPC;
            AddedDPC = DPC * DPCMultiplyer;
        }
        //wieviel teurer wirds (click)
        AddedClickAmount = AmountPerClick * (UpgradeCount / x) * ClickAmountMultiplier;
        print(AddedClickAmount);
        //alle 10 level mehr +jeder click
        if(UpgradeCount %10 ==0)
        {
            AmountPerClick += (int)AddedClickAmount;
        }

        DPCDisplay.text = DPC.ToString();
        DPCUpdateDisplay.text = AddedDPC.ToString();
    }

    void UpdateMoneyDisplay() {
        MoneyDisplay.text = Money.ToString();
    }
}