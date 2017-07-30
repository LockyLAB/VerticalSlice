using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

	PlayerController pc;
	AudioSource walking;

	// Use this for initialization
	void Start () {
		pc = GetComponent<PlayerController>();
		walking = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pc.notWalking == false && walking.isPlaying == false) {
			walking.Play ();

		} 

	
	}
}
