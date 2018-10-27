using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelton : MonoBehaviour {

    public bool NewGame = false;

    public static Singelton S = null;

    void Awake() {
        if (S == null) {
            S = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(this.gameObject);
        }
    }
}
