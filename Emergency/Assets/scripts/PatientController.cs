﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    [SerializeField] float DeathDelay = 0.5f;
    uint getMoney;
    GameManager gameManager;
    Vector2 AnimationTarget;
    PatientLoader patientLoader;
    Healthbar healthbar;
    [SerializeField] GameObject Partikle;
    List<AudioClip> HitSounds;
    List<AudioClip> DeathSounds;
    AudioSource SoundPlayer;
    GameObject Deathface;
    GameObject Eyes;
    GameObject Mouth;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();
        patientLoader = this.gameObject.GetComponent<PatientLoader>();
        HitSounds = new List<AudioClip>(Resources.LoadAll<AudioClip>("HITSOUNDS"));
        DeathSounds = new List<AudioClip>(Resources.LoadAll<AudioClip>("DEATHSOUNDS"));
        SoundPlayer = this.gameObject.GetComponent<AudioSource>();
        Deathface = GameObject.Find("deathface");
        Eyes = GameObject.Find("eyes");
        Mouth = GameObject.Find("mouth");
        Deathface.SetActive(false);
	}
	
	void Update ()
    {
	}

    public void Die()
    {
        Deathface.SetActive(true);
        Eyes.SetActive(false);
        Mouth.SetActive(false);
        SoundPlayer.clip = DeathSounds[Random.Range(0, DeathSounds.Count - 1)];
        SoundPlayer.Play();
        gameManager.RealeaseMoney(getMoney);
        Invoke("DyingInvoke",DeathDelay);
    }
    void DyingInvoke()
    {
        patientLoader.RandomizePatient();
    }

    public void ResetPatient(float life, uint money)
    {
        Deathface.SetActive(false);
        Mouth.SetActive(true);
        Eyes.SetActive(true);
        getMoney = money;
        print(healthbar);
        healthbar.SetMaxHealth(life);
    }

    public void DealDamage(float dmg)
    {
        healthbar.Decrease(dmg);
    }

    private void OnMouseDown()
    {
        SoundPlayer.clip = HitSounds[Random.Range(0, HitSounds.Count - 1)];
        SoundPlayer.Play();
        gameManager.MakeHit();
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Partikle.transform.position = new Vector3(temp.x, temp.y, -1);

        print("POS:" + Partikle.transform.position.ToString());
        Partikle.GetComponent<ParticleSystem>().Play();
        //Partiel abfeuern
    }
}
