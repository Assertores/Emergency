using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

    GameManager gameManager;

    [SerializeField] GameObject Krankheiten;
    KrankheitenElement []KE;
    [SerializeField] string Path;
    [SerializeField] string FileName;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        KE = Krankheiten.GetComponentsInChildren<KrankheitenElement>();
    }

    public void Save() {
        Directory.CreateDirectory(Path);
        File.WriteAllText(Path + FileName + ".save", "your realy awesome");
        File.AppendAllText(Path + FileName + ".save", "you are awesome");
        foreach (KrankheitenElement it in KE) {
            it.GetCount();//in datei schreiben
        }
        gameManager.GetCurrentMoney(); //in datei schreiben
        gameManager.GetCurrentDPC().ToString(); //in datei schreiben
    }
    public void Load() {
        //szenenwechsel machen
        //daten rein laden
    }
}
