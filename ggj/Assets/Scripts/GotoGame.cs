using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GotoGame : MonoBehaviour {
    public GameObject vidplay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if ( vidplay.GetComponent<VideoPlayer>().frame>10) { 
        if (vidplay.GetComponent<VideoPlayer>().isPlaying == false )
        {
            Application.LoadLevel("StartScreen");
        }
	}
    }
}
