using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class KrankheitenElement : MonoBehaviour {

    public GameObject Virus;
    public String Name;
    public Image Thumpnail;
    public uint Kost;
    public float Dps;
    public uint Count = 0;

    private void Start() {
        //die ganze sachen in das prefap schreiben
    }

    private void Update() {
        if (Count == 0)
            return;
        //mach schaden
    }

    public void Buy(uint Buy_count = 1) {
        //is buy able
        if(Count == 0) {
            Instantiate(Virus,this.transform);
        }
        Count += Buy_count;
        //darstellung von kosten werden erhöht
        //darstellung von DPS wird erhöht
    }

}
