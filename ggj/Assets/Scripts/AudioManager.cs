using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public AudioClip BackgroundMusic;
	public AudioClip MenuBackgroundMusic;
	public AudioClip ShootSound;
	public AudioClip HitSound;
	public AudioClip VictorySound;
	public AudioClip ButtonClickSound;
	public AudioClip PowerUpSound;


	//public AudioSource MainSoundSource;
	private AudioSource P1ShootSource;
	private AudioSource P2ShootSource;
	private AudioSource HitSource;
	public AudioSource ButtonClickSource;
	private AudioSource PowerUpSource;

	public GameObject Background;
	public GameObject MainMenuBackground;
	public GameObject P1;
	public GameObject P2;
	public GameObject HitSoundSource;
	public GameObject PowerPickupSource;

	public bool IsMainMenu;
	// Use this for initialization
	void Start () {
		if (IsMainMenu) {
			SetStartmenuBackgroundSound ();
		} else {
			SetBackgroundSound ();
		} 
		SetGameplaySounds ();
		SetHitSoundSource ();
		SetPowerUpSource ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetBackgroundSound() {
		Background.GetComponent<AudioSource>().clip = BackgroundMusic;
		Background.GetComponent<AudioSource>().Play ();
	}

	private void SetStartmenuBackgroundSound () {
		MainMenuBackground.GetComponent<AudioSource>().clip = MenuBackgroundMusic;
		MainMenuBackground.GetComponent<AudioSource>().Play ();
		
	} 

	private void SetGameplaySounds() {
		P1ShootSource = P1.GetComponent<AudioSource> ();
		P2ShootSource = P2.GetComponent<AudioSource> ();
		P1ShootSource.clip = ShootSound;
		P2ShootSource.clip = ShootSound;
	}

	private void SetHitSoundSource() {
		HitSoundSource.GetComponent<AudioSource> ().clip = HitSound;
	}

	private void SetPowerUpSource() {
		PowerPickupSource.GetComponent<AudioSource> ().clip = PowerUpSound;
	}


	// -------------------------


	public void P1Shoot() {
		P1ShootSource.Play ();
	}

	public void P2Shoot() {
		P2ShootSource.Play ();
	}

	public void GameOverSound() {
		Background.GetComponent<AudioSource> ().clip = VictorySound;
		Background.GetComponent<AudioSource>().Play ();
	}

	public void HitSomething() {
		HitSoundSource.GetComponent<AudioSource> ().Play();
	}

	public void PowerUPPickup() {
		PowerPickupSource.GetComponent<AudioSource> ().Play ();
	}


}
