using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Save();
            Application.Quit();
        }
    }

    public void Save() {
        Directory.CreateDirectory(Path);
        File.WriteAllText(Path + "/" + FileName + ".save", System.DateTime.Now.ToUniversalTime().ToString() + System.Environment.NewLine);
        foreach (KrankheitenElement it in KE) {
            File.AppendAllText(Path + "/" + FileName + ".save", it.GetCount().ToString() + System.Environment.NewLine);
        }
        File.AppendAllText(Path + "/" + FileName + ".save", gameManager.GetCurrentMoney().ToString() + System.Environment.NewLine);
        File.AppendAllText(Path + "/" + FileName + ".save", gameManager.GetCurrentDPC().ToString());
    }
    public void Load() {
        //daten rein laden
        //hochrechnen wiefiel in der idle zeit gefarmd wurde
    }
}
