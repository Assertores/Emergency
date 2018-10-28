using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
