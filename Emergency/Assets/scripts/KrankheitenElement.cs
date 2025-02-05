﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class KrankheitenElement : MonoBehaviour {

    [SerializeField] GameObject Virus;
    [SerializeField] String Name;
    [SerializeField] Text _NameText;
    [SerializeField] Sprite Icon;
    [SerializeField] Image _IconImage;
    [SerializeField] Text _CostText;
    [SerializeField] Text _DpsText;
    [SerializeField] uint StartCost;
    [Range(0, 1)]
    [SerializeField] float CostMultiplyer = 1;
    [SerializeField] float StartDps;
    [Range(0,1)]
    [SerializeField] float DpsMultiplyer = 1;
    uint Count = 0;
    uint Buy_amount = 1;

    GameObject GCost;
    GameObject GDps;

    GameManager gameManager;

    private void Start() {
        _NameText.text = Name;
        _IconImage.sprite = Icon;
        _CostText.text = GetCost().ToString();
        _DpsText.text = GetDps().ToString();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update() {
        if (Count == 0)
            return;
        gameManager.DealDamage(GetDps() * Time.deltaTime);
    }

    public void Buy() {
        if (gameManager.Buy(GetCost())) {
            if (Count == 0) {
                Instantiate(Virus);
            }
            Count += Buy_amount;
            _CostText.text = GetCost().ToString();
            _DpsText.text = GetDps().ToString();
        }
        
    }

    uint GetCost() {
        return (uint)(CostMultiplyer * Count * Count) + StartCost;//funktion die ausrechnet wie fiels jetzt kossted
    }

    float GetDps() {
        return DpsMultiplyer * Count * Count + StartDps;
    }

    public uint GetCount() {
        return Count;
    }
}
