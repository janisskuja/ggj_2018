﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed;
	private Rigidbody rb;
	public bool team;
	public float strayFactor;
	public float powerUpTimer = 0.2f;
	private float powerUpTime;
	public bool isPowered = false;
	public bool timerStarted = false;
	private float randomNumberZ;
	private AudioManager audioManager;
    private string player_input;
    public float playerVolocityBonus;

	void Start()
	{   

		rb = GetComponent<Rigidbody>();
		if (team) speed = speed * (-1);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);
        if (!team)
            player_input = "Vertical1";
        else
            player_input = "Vertical2";
        rb.velocity = transform.right * speed + transform.forward * randomNumberZ + transform.forward *Input.GetAxis(player_input)* playerVolocityBonus;
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        
	}
	public void setPowered() {
		isPowered = true;
		gameObject.GetComponentInChildren<Light> ().range = 4;
		transform.localScale = new Vector3 (4f, 100f, 4f);
	}
	public void startPowerUp() {
		if (!timerStarted) {
			timerStarted = true;
			powerUpTime = Time.time + powerUpTimer;
		}
	}
	void Update() {
		if (isPowered && timerStarted) {
			isPowered = Time.time < powerUpTime;
		}
	}

	void OnDestroy() {
		audioManager.HitSomething ();
	}

}