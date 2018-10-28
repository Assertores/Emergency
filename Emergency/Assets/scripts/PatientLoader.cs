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

    uint KillCount = 0;
    float AddedHealth =0;
    [SerializeField] uint PatientHealth = 10;
    [SerializeField] float HealthMultiplier = 1;

    [SerializeField] float AmountPerDeath = 10;
    [SerializeField]float AmountPerSecond = 1;
    [SerializeField]float IdleAmountMultiplier = 1;
    [SerializeField] uint DeathAmountMultiplier = 1;
    float AddedClickAmount;
    int ClickDamageLevel;


    PatientController patientController;

    void Start()
    {
        Sprite[] arms = Resources.LoadAll<Sprite>("ARM");
        Sprite[] torso = Resources.LoadAll<Sprite>("TORSO");
        Sprite[] heads = Resources.LoadAll<Sprite>("HEAD");
        Sprite[] feet = Resources.LoadAll<Sprite>("FEET");

        patientController = this.gameObject.GetComponent<PatientController>();

        Head = GameObject.Find("head").GetComponent<SpriteRenderer>();
        Torso = GameObject.Find("torso").GetComponent<SpriteRenderer>();
        Feet = GameObject.Find("feet").GetComponent<SpriteRenderer>();
        Arm = GameObject.Find("arm").GetComponent<SpriteRenderer>();
        RandomizePatient(true);
    }	
	void Update ()
    {
		
	}
    public void RandomizePatient(bool firstPatient = false)
    {
        if(arms != null)CurrentArm = arms[Random.Range(0, arms.Length)];//randomized sprites
        if(torso!= null)CurrentTorso = torso[Random.Range(0, torso.Length)];
        if(heads != null)CurrentHead = heads[Random.Range(0, heads.Length)];
        if(feet != null)CurrentFeet = feet[Random.Range(0, feet.Length)];

        Head.sprite = CurrentHead;//setzt aktive sprites
        Feet.sprite = CurrentFeet;
        Torso.sprite = CurrentTorso;
        Arm.sprite = CurrentArm;
        patientController.ResetPatient(Life(), Money());

        if (!firstPatient)
        {
            KillCount++;
            UpdateAddedHealth();
        }
    }
    void UpdateAddedHealth()
    {
        if(KillCount %10 == 0)
        {
            AddedHealth = PatientHealth * HealthMultiplier;
        }
    }
    float Life()
    {
        return PatientHealth + AddedHealth;
    }
    uint Money()
    {
        AmountPerDeath = Mathf.RoundToInt(AmountPerDeath + KillCount * DeathAmountMultiplier);
        return (uint)AmountPerDeath;
    }

}
