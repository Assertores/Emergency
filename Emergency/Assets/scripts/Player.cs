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
    [SerializeField] Text AddedClickAmountDisplay;
    [SerializeField] Text ClickAmountDisplay;
    [SerializeField] Text CostDisplay;
    [SerializeField] uint StartCost;
    [Range(0, 1)]
    [SerializeField] float CostMultiplyer = 1;
    [SerializeField] int AmountPerClick = 1;
    [SerializeField] float ClickAmountMultiplier;
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
        UpdatePlayerFeald();
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
    }

    public void UpgradeClick() {
        if (Money < GetCost())
            return;
        Money -= GetCost();
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

        UpdatePlayerFeald();
    }

    void UpdatePlayerFeald() {
        DPCDisplay.text = DPC.ToString();
        DPCUpdateDisplay.text = AddedDPC.ToString();
        AddedClickAmountDisplay.text = AddedClickAmount.ToString();
        ClickAmountDisplay.text = AmountPerClick.ToString();
        CostDisplay.text = GetCost().ToString();
    }

    void UpdateMoneyDisplay() {
        MoneyDisplay.text = NumberToString.MakeString(Money);
    }

    uint GetCost() {
        return (uint)(CostMultiplyer * UpgradeCount * UpgradeCount + StartCost);//funktion die ausrechnet wie fiels jetzt kossted
    }
}