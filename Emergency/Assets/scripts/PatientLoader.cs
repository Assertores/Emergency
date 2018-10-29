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
    [SerializeField] uint MultiplierCount = 10;

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
        mund = new List<Sprite>(Resources.LoadAll<Sprite>("MUND"));
        body = new List<Sprite>(Resources.LoadAll<Sprite>("BODY"));
        haare = new List<Sprite>(Resources.LoadAll<Sprite>("HAARE"));

       
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
        if(arms.Count != 0)CurrentArm = arms[Random.Range(0, arms.Count)];//randomized sprites
        if(torso.Count != 0) CurrentTorso = torso[Random.Range(0, torso.Count)];
        if(heads.Count != 0) CurrentHead = heads[Random.Range(0, heads.Count)];
        if(feet.Count != 0) CurrentFeet = feet[Random.Range(0, feet.Count)];
   
        if (augen.Count != 0) CurrentEyes = augen[Random.Range(0, augen.Count)];
        if (hosen.Count != 0) CurrentShorts = hosen[Random.Range(0, hosen.Count)];
        if (mund.Count != 0) CurrentMouth = mund[Random.Range(0, mund.Count)];
        if (body.Count != 0) CurrentBody = body[Random.Range(0, body.Count)];
        if (haare.Count != 0) Hair.sprite = haare[Random.Range(0, haare.Count)];

        Head.sprite = CurrentHead;//setzt aktive sprites
        Feet.sprite = CurrentFeet;
        Torso.sprite = CurrentTorso;
        Arm.sprite = CurrentArm;

        Augen.sprite = CurrentEyes;
        Hosen.sprite = CurrentShorts;
        Mund.sprite = CurrentMouth;
        Body.sprite = CurrentBody;
        //Hair.sprite = CurrentHair;
        //print(CurrentEyes);
        
        if (!firstPatient)
        {
            KillCount++;
            UpdateAddedHealth();
        }
        print("New Life: " + Life());//----- ----- LOG ----- -----
        patientController.ResetPatient(Life(), Money());
    }
    void UpdateAddedHealth()
    {
        if(KillCount %MultiplierCount == 0)//%10 für den GameDesigner einstellbar gemacht
        {
            AddedHealth = Life() * HealthMultiplier;//hohlt sich aktuelles life nicht start life
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
