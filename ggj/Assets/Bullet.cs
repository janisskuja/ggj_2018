using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject player;
    public bool team;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (team) speed = speed * (-1);
        rb.velocity = transform.right * speed;
    }
}