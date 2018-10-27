using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

    GameManager gameManager;

    [SerializeField] GameObject Krankheiten;
    KrankheitenElement []KE;
    [SerializeField] string Path;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        KE = Krankheiten.GetComponentsInChildren<KrankheitenElement>();
    }

    public void Save() {
        foreach(KrankheitenElement it in KE) {
            it.GetCount();//in datei schreiben
        }
        gameManager.GetCurrentMoney(); //in datei schreiben
        gameManager.GetCurrentDPC(); //in datei schreiben
    }
    public void Load() {
        //szenenwechsel machen
        //daten rein laden
    }
}
