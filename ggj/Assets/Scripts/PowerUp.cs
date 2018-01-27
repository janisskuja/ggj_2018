using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public int HitCount = 1;
    public bool TeamBlue;
	private int hits = 0;

	private AudioManager audioManager;
 

    void Start()  {
        transform.GetComponent<Renderer>().material.color = TeamBlue ? Color.magenta : Color.green;
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>().team && TeamBlue || !other.GetComponent<Bullet>().team && !TeamBlue)
            hits++;

        if (hits >= HitCount)
        {
			Generator.instance.AskForSpawn(TeamBlue);
            Destroy(gameObject);
        }
    }

	void OnDestroy() {
		audioManager.PowerUPPickup ();
	}
}
