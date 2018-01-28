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
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    void OnTriggerEnter(Collider other)
    {
		Bullet bullet = other.GetComponent<Bullet> ();
//		if (bullet.team && TeamBlue || !bullet.team && !TeamBlue) {
			bullet.setPowered ();
			hits++;
//		}

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
