using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed;
	private Rigidbody rb;
	public bool team;
	public float strayFactor;

	private float randomNumberZ;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (team) speed = speed * (-1);
		var randomNumberZ = Random.Range(-strayFactor, strayFactor);
		rb.velocity = transform.right * speed+ transform.forward*randomNumberZ;
	}

}