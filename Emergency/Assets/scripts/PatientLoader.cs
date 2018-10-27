using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLoader : MonoBehaviour
{
    Sprite []arms;
    Sprite []torso;
    Sprite []heads;
    Sprite []feet;
   
    Sprite CurrentArm;
    Sprite CurrentTorso;
    Sprite CurrentHead;
    Sprite CurrentFeet;

    SpriteRenderer Arm;
    SpriteRenderer Torso;
    SpriteRenderer Feet;
    SpriteRenderer Head;

    PatientController patientController;

    void Start()
    {
        Sprite[] arms = Resources.LoadAll<Sprite>("ARMS");
        Sprite[] torso = Resources.LoadAll<Sprite>("TORSO");
        Sprite[] heads = Resources.LoadAll<Sprite>("HEADS");
        Sprite[] feet = Resources.LoadAll<Sprite>("HEADS");

        patientController = this.gameObject.GetComponent<PatientController>();

        Head = GameObject.Find("head").GetComponent<SpriteRenderer>();
        Torso = GameObject.Find("torso").GetComponent<SpriteRenderer>();
        Feet = GameObject.Find("feet").GetComponent<SpriteRenderer>();
        Arm = GameObject.Find("arm").GetComponent<SpriteRenderer>();
    }	
	void Update ()
    {
		
	}
    public void RandomizePatient()
    {
        CurrentArm = arms[Random.Range(0, arms.Length)];//randomized sprites
        CurrentTorso = torso[Random.Range(0, torso.Length)];
        CurrentHead = heads[Random.Range(0, heads.Length)];
        CurrentFeet = feet[Random.Range(0, feet.Length)];

        Head.sprite = CurrentHead;//setzt aktive sprites
        Feet.sprite = CurrentFeet;
        Torso.sprite = CurrentTorso;
        Arm.sprite = CurrentArm;
        patientController.ResetPatient(life(), money());
    }
    float life()
    {
        return 4;
    }
    uint money()
    {
        return 10;
    }

}
