using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLoader : MonoBehaviour
{
    Sprite[] arms;//optional
    Sprite[] torso;
    Sprite[] heads;
    Sprite[] feet;

    Sprite CurrentArm;
    Sprite CurrentTorso;
    Sprite CurrentHead;
    Sprite CurrentFeet;

    SpriteRenderer Arm;
    SpriteRenderer Torso;
    SpriteRenderer Feet;
    SpriteRenderer Head;

    Sprite[] augen;//nicht optional
    Sprite[] hosen;
    Sprite[] mund;
    Sprite[] haare;
    Sprite[] body;

    Sprite CurrentEyes;
    Sprite CurrentShorts;
    Sprite CurrentMouth;
    Sprite CurrentHair;
    Sprite CurrentBody;

    SpriteRenderer Augen;
    SpriteRenderer Hosen;
    SpriteRenderer Mund;
    SpriteRenderer Hair;
    SpriteRenderer Body;

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

        Sprite[] augen = Resources.LoadAll<Sprite>("AUGEN");
        Sprite[] hosen = Resources.LoadAll<Sprite>("HOSE");
        Sprite[] mund = Resources.LoadAll<Sprite>("MUND");
        Sprite[] body = Resources.LoadAll<Sprite>("BODY");
        Sprite[] haare = Resources.LoadAll<Sprite>("HAARE");

        patientController = this.gameObject.GetComponent<PatientController>();

        Head = GameObject.Find("head").GetComponent<SpriteRenderer>();
        Torso = GameObject.Find("torso").GetComponent<SpriteRenderer>();
        Feet = GameObject.Find("feet").GetComponent<SpriteRenderer>();
        Arm = GameObject.Find("arm").GetComponent<SpriteRenderer>();

        Augen = GameObject.Find("eyes").GetComponent<SpriteRenderer>();
        Hosen = GameObject.Find("shorts").GetComponent<SpriteRenderer>();
        Mund = GameObject.Find("mouth").GetComponent<SpriteRenderer>();
        Body = GameObject.Find("body").GetComponent<SpriteRenderer>();
        Hair = GameObject.Find("hair").GetComponent<SpriteRenderer>();

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

        if (augen != null) CurrentEyes = augen[Random.Range(0, augen.Length)];
        if (hosen != null) CurrentShorts = hosen[Random.Range(0, hosen.Length)];
        if (mund != null) CurrentMouth = mund[Random.Range(0, mund.Length)];
        if (body != null) CurrentBody = body[Random.Range(0, body.Length)];
        if (Hair != null) CurrentHair = haare[Random.Range(0, haare.Length)];

        Head.sprite = CurrentHead;//setzt aktive sprites
        Feet.sprite = CurrentFeet;
        Torso.sprite = CurrentTorso;
        Arm.sprite = CurrentArm;

        Augen.sprite = CurrentEyes;
        Hosen.sprite = CurrentShorts;
        Mund.sprite = CurrentMouth;
        Body.sprite = CurrentBody;
        Hair.sprite = CurrentHair;

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
