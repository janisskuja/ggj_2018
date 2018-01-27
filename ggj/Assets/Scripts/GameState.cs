using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	public float timer = 120;
	public Text timerText;
	public Text blueScoreText;
	public Text redScoreText;
	public int redScore = 0;
	public int blueScore = 0;

	// Use this for initialization
	void Start () {
		timerText = GameObject.FindGameObjectWithTag ("GameTime").GetComponent<Text>();
		blueScoreText = GameObject.FindGameObjectWithTag ("BlueScore").GetComponent<Text>();
		redScoreText = GameObject.FindGameObjectWithTag ("RedScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 1f) {
			timer -= Time.deltaTime;
		} else {
			if (redScore > blueScore) {
				Application.LoadLevel ("EndScreen2");
			} else {
				Application.LoadLevel ("EndScreen1");
			}
		}
	}

	void OnGUI() {
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		timerText.text = niceTime;
		blueScoreText.text = "" + blueScore;
		redScoreText.text = "" + redScore;
	}
}
