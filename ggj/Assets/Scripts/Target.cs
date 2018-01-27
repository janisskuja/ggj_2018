using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int HitCount = 1;
    public bool TeamBlue;
    private int hits = 0;
	public GameState gameState;

	void Start() {
		transform.GetComponent<Renderer> ().material.color = TeamBlue ? Color.white : Color.black;
		gameState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameState> ();
	}

    void OnTriggerEnter(Collider other)
    {
		Bullet bullet = other.GetComponent<Bullet> ();
		if (bullet.team && !TeamBlue || !bullet.team && TeamBlue)
            hits++;

        if (hits >= HitCount)
        {
			if (bullet.team) {
				gameState.blueScore += 500;
			} else {
				gameState.redScore += 500;
			}
			Destroy (gameObject);
        }
        //todo increase score
    }
}
