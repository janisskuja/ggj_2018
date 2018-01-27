using UnityEngine;

public class GridCube : MonoBehaviour {

	public bool isBlue;
	public GameState gameState;

	void Start () {
		gameObject.transform.localScale = new Vector3(1f, Random.Range (0.1f, 2f), 1f);
		gameState = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameState> ();
	}

	void Update () {
		gameObject.GetComponent<Renderer> ().material.color = isBlue ? Color.blue : Color.red;
	}

	void OnTriggerEnter (Collider other) {
		bool tmpBlue = isBlue;
		Bullet bullet = other.gameObject.GetComponent<Bullet> ();
		isBlue = bullet.team;
		if (tmpBlue != isBlue) {
			if (isBlue) {
				gameState.blueScore++;
			} else {
				gameState.redScore++;
			}
			if (bullet.isPowered) {
				bullet.startPowerUp ();
				return;
			}
			Destroy (other.gameObject);
		}
	}
}