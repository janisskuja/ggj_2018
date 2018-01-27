using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int HitCount = 1;
    public bool TeamBlue;
    private int hits = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>().team && !TeamBlue)
            hits++;

        if (hits > HitCount)
        {
            Destroy(gameObject);

            Debug.Log(" dest");
        }
        //todo increase score
    }
}
