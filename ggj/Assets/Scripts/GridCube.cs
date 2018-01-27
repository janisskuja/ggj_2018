using UnityEngine;

public class GridCube : MonoBehaviour {

	public bool isBlue;

	void Start () {
		gameObject.transform.localScale = new Vector3(1f, Random.Range (0.1f, 2f), 1f);
	}

	void Update () {
		gameObject.GetComponent<Renderer> ().material.color = isBlue ? Color.blue : Color.red;
	}

	void OnTriggerEnter (Collider other) {
		bool tmpBlue = isBlue;
		Bullet bullet = other.gameObject.GetComponent<Bullet> ();
		isBlue = bullet.team;
		if (tmpBlue != isBlue) {
			if (bullet.isPowered) {
				bullet.startPowerUp ();
				return;
			}
			Destroy (other.gameObject);
		}
	}
}