using System.Collections;
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
    bool dead = false;//ist true solange der patzient gewächselt wird

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

    public void Die()
    {
        dead = true;
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
        healthbar.SetMaxHealth(life);
        dead = false;
    }

    public void DealDamage(float dmg)
    {
        if(!dead)//man kann nur lebenden patzienten schaden machen
            healthbar.Decrease(dmg);
    }

    private void OnMouseDown()
    {
        SoundPlayer.clip = HitSounds[Random.Range(0, HitSounds.Count - 1)];
        SoundPlayer.Play();
        gameManager.MakeHit();
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Partikle.transform.position = new Vector3(temp.x, temp.y, -1);

        Partikle.GetComponent<ParticleSystem>().Play();
        //Partiel abfeuern
    }
}
