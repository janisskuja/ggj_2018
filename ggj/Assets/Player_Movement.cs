using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float zMin, zMax;
}

public class Player_Movement : MonoBehaviour {

    public float speed;
    public bool team; // 0=left , 1=right
    public Boundary boundary;
    private string player_input; 
    public float x_position;
    public Bullet shot;
    public float fireRate;

    private float nextFire;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!team) x_position = x_position * (-1);
		transform.GetComponent<Renderer> ().material.color = team ? Color.blue : Color.red;
    }

    private void Update()
    {
        if (Input.GetButton(team?"Fire1": "Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shot.team = team;
			Instantiate(shot, new Vector3(transform.position.x, 3f, transform.position.z), transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        if (!team)
            player_input = "Vertical1";
        else
            player_input = "Vertical2";

            float moveVertical = Input.GetAxis(player_input);

        Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(x_position,0.0f,Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
);
    }

   
}
