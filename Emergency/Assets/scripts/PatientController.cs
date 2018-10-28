using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    uint getMoney;
    GameManager gameManager;
    public Animator PatientAnim;
    Vector2 AnimationTarget;
    PatientLoader patientLoader;
    Healthbar healthbar;
    [SerializeField] GameObject Partikle;
    List<AudioClip> HitSounds;
    List<AudioClip> DeathSounds;
    AudioSource SoundPlayer;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        healthbar = GetComponent<Healthbar>();
        patientLoader = this.gameObject.GetComponent<PatientLoader>();
        //PatientAnim = this.gameObject.GetComponentInChildren<Animator>();
        HitSounds = new List<AudioClip>(Resources.LoadAll<AudioClip>("HITSOUNDS"));
        DeathSounds = new List<AudioClip>(Resources.LoadAll<AudioClip>("DEATHSOUNDS"));
        SoundPlayer = this.gameObject.GetComponent<AudioSource>();
	}
	
	void Update ()
    {
	}

    public void Die()
    {
        SoundPlayer.clip = DeathSounds[Random.Range(0, DeathSounds.Count - 1)];
        SoundPlayer.Play();
        gameManager.RealeaseMoney(getMoney);
        //PatientAnim.SetBool("Die", true);
        patientLoader.RandomizePatient();
    }

    public void ResetPatient(float life, uint money)
    {
        getMoney = money;
        print(healthbar);
        healthbar.SetMaxHealth(life);
        PatientAnim.SetBool("Die", false);
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
