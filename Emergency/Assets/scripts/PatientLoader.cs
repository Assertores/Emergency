using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientLoader : MonoBehaviour
{
    List<Sprite> arms;
    List<Sprite> torso;
    List<Sprite> heads;
    List<Sprite> feet;

    Sprite CurrentArm;
    Sprite CurrentTorso;
    Sprite CurrentHead;
    Sprite CurrentFeet;

    SpriteRenderer Arm;
    SpriteRenderer Torso;
    SpriteRenderer Feet;
    SpriteRenderer Head;

    List<Sprite> augen;
    List<Sprite> hosen;
    List<Sprite> mund;
    List<Sprite> haare;
    List<Sprite> body;

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
        arms = new List<Sprite>(Resources.LoadAll<Sprite>("ARM"));
        torso = new List<Sprite>(Resources.LoadAll<Sprite>("TORSO"));
        heads = new List<Sprite>(Resources.LoadAll<Sprite>("HEAD"));
        feet = new List<Sprite>(Resources.LoadAll<Sprite>("FEET"));
        augen = new List<Sprite>(Resources.LoadAll<Sprite>("AUGEN"));
        hosen = new List<Sprite>(Resources.LoadAll<Sprite>("HOSE"));
        mund = new List<Sprite>(Resources.LoadAll<Sprite>("MIND"));
        body = new List<Sprite>(Resources.LoadAll<Sprite>("BODY"));
        haare = new List<Sprite>(Resources.LoadAll<Sprite>("HAARE"));
        print(augen[0]);

       
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
        print(Augen);
        RandomizePatient(true);
    }	
	void Update ()
    {
		
	}
    public void RandomizePatient(bool firstPatient = false)
    {
        if(arms.Count != 0)CurrentArm = arms[Random.Range(0, arms.Count-1)];//randomized sprites
        if(torso.Count != 0) CurrentTorso = torso[Random.Range(0, torso.Count-1)];
        if(heads.Count != 0) CurrentHead = heads[Random.Range(0, heads.Count-1)];
        if(feet.Count != 0) CurrentFeet = feet[Random.Range(0, feet.Count-1)];
        print(Augen);
        print(augen[0]);
        print("1");
        if (augen.Count != 0) CurrentEyes = augen[Random.Range(0, augen.Count-1)];
        if (hosen.Count != 0) CurrentShorts = hosen[Random.Range(0, hosen.Count-1)];
        if (mund.Count != 0) CurrentMouth = mund[Random.Range(0, mund.Count-1)];
        if (body.Count != 0) CurrentBody = body[Random.Range(0, body.Count-1)];
        if (haare.Count != 0) CurrentHair = haare[Random.Range(0, haare.Count-1)];

        Head.sprite = CurrentHead;//setzt aktive sprites
        Feet.sprite = CurrentFeet;
        Torso.sprite = CurrentTorso;
        Arm.sprite = CurrentArm;

        Augen.sprite = CurrentEyes;
        Hosen.sprite = CurrentShorts;
        Mund.sprite = CurrentMouth;
        Body.sprite = CurrentBody;
        Hair.sprite = CurrentHair;
        print(CurrentEyes);

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
