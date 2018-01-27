using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour {
    public GameObject Image1;
    public GameObject Image2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if ( Input.GetAxis("Vertical1") > 0)
        {
            Image1.SetActive(true);
            Image2.SetActive(false);
        }
        if (Input.GetAxis("Vertical1") < 0)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
        }
    }
}
