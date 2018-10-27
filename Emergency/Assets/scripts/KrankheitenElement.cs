using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class KrankheitenElement : MonoBehaviour {

    [SerializeField] GameObject Virus;
    [SerializeField] String Name;
    [SerializeField] Sprite Icon;
    [SerializeField] uint StartCost;
    [SerializeField] float StartDps;
    uint Count = 0;
    uint Buy_count = 1;

    GameObject GCost;
    GameObject GDps;

    GameManager gameManager;

    private void Start() {
        GameObject GName = GameObject.Find("Name");
        if (GName) {
            GName.GetComponent<Text>().text = Name;
        }
        GameObject GIcon = GameObject.Find("Icon");
        if (GIcon) {
            GIcon.GetComponent<Image>().sprite = Icon;
        }
        GCost = GameObject.Find("Cost");
        if (GCost) {
            GCost.GetComponent<Text>().text = GetCost().ToString();
        }
        GDps = GameObject.Find("DPS");
        if (GDps) {
            GDps.GetComponent<Text>().text = GetDps().ToString();
        }
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update() {
        if (Count == 0)
            return;
        gameManager.DealDamage(GetDps() * Time.deltaTime);
    }

    public void Buy() {
        gameManager.Buy(GetCost());
        if(Count == 0) {
            Instantiate(Virus,this.transform);
        }
        Count += Buy_count;
        if (GCost) {
            GCost.GetComponent<Text>().text = GetCost().ToString();
        }
        if (GDps) {
            GDps.GetComponent<Text>().text = GetDps().ToString();
        }
    }

    uint GetCost() {
        return StartCost;//funktion die ausrechnet wie fiels jetzt kossted
    }

    float GetDps() {
        return StartDps;//funktion die ausrechnet wie fiel schaden jetzt gemacht wird
    }
}
