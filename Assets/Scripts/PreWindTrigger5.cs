﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWindTrigger5 : MonoBehaviour {

	public AudioClip creature;
	public float creatureVolume = 1f;
	WindZone wind;
	public GameObject lightGuideR;
	public GameObject lightGuideL;
	public Animator animator;

	// Use this for initialization
	void Start () {
		wind = GameObject.FindWithTag ("Wind").GetComponent<WindZone> ();
	//	lightGuide = GameObject.FindWithTag ("FloodLight");
	}

	void OnTriggerEnter(){
		wind.windMain = 7f;
		StartCoroutine (FloodLights ());
	
	}

	private IEnumerator FloodLights (){
		AudioSource.PlayClipAtPoint (creature, transform.position, creatureVolume);
		yield return new WaitForSeconds (1f);
		animator.SetTrigger ("LightScramble");
		yield return new WaitForSeconds (0.5f);
		lightGuideR.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		lightGuideL.SetActive (true);

	}


	void OntriggerExit(){
		
		Destroy (this.gameObject);
	}

}
