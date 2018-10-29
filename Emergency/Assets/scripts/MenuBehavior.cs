using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

    [SerializeField] GameObject Menu;

    private void Start() {
        Close();
    }

    public void Open() {
        Menu.SetActive(true);
    }
    public void Close() {
        Menu.SetActive(false);
    }
    public void Exit() {
        Application.Quit();
    }
}
