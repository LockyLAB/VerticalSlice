﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTrigger : MonoBehaviour {
	
	public AudioClip creatureSound;
	public AudioClip heavyBreathing;
	public float creatureVolumeLevel = 1f;
	public float breathingVolumeLevel = 1f;
	PlayerController pc;



	void Start (){
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter(){
		StartCoroutine (Creature ());
		}

	void OnTriggerExit(){
		pc.walkSpeed = 0.08f;
		Destroy (this.gameObject);
	}

	private IEnumerator Creature (){
		AudioSource.PlayClipAtPoint (creatureSound, transform.position, creatureVolumeLevel);
		yield return new WaitForSeconds (1f);
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolumeLevel);
	}

}
