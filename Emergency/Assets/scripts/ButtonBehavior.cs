using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    KrankheitenElement[] KE;
    int CurrentPossition = 0;
    float dist = 0;

    // Use this for initialization
    void Start () {
        KE = this.GetComponentsInChildren<KrankheitenElement>();
        for(int i = 3; i < KE.Length; i++) {
            KE[i].gameObject.SetActive(false);
        }
        if(KE.Length >= 2) {
            dist = KE[1].transform.position.x - KE[0].transform.position.x;
        }
    }

    public void Forward() {
        if(KE.Length > CurrentPossition + 3) {
            KE[CurrentPossition].gameObject.SetActive(false);
            KE[CurrentPossition+3].gameObject.SetActive(true);
            this.transform.position -= new Vector3(dist, 0, 0);
            CurrentPossition++;
        }
    }
	
    public void Backward() {
        if(CurrentPossition > 0) {
            CurrentPossition--;
            KE[CurrentPossition].gameObject.SetActive(true);
            KE[CurrentPossition + 3].gameObject.SetActive(false);
            this.transform.position += new Vector3(dist, 0, 0);
        }
    }
}
