using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger : MonoBehaviour {

	WindZone wind;
	PlayerController pc;
	public float windMain = 1f;
	public AudioClip creaturStomp;
	public AudioClip creatureRoar;
	public AudioClip hecticWind;
	public AudioClip heavyBreathing;
	public float creatureStompVolume = 1f;
	public float windVolume = 1f;
	public float breathingVolume = 1f;
	public float creatureRoarVolume = 1f;
	public bool isWindy = false;
	public int counter;

	void Start () {
		wind = GameObject.FindWithTag ("Wind").GetComponent<WindZone> ();
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter(){
		AudioSource.PlayClipAtPoint (creaturStomp, transform.position, creatureStompVolume);
		AudioSource.PlayClipAtPoint (creatureRoar, transform.position, creatureRoarVolume);
		isWindy = true;
}

	void OntriggerExit(){
		AudioSource.PlayClipAtPoint (hecticWind, transform.position, windVolume);
		Debug.Log ("Wind");
		wind.windMain = 8f;
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolume);
		Debug.Log ("BREATHE");
	}


	void Update(){
		if(isWindy == true){
			counter++;
			if(counter > 40){
				counter = 40;
				if(counter == 40 && pc.walkSpeed == 0.06f){
					pc.walkSpeed = 0.18f;
				}
			}

		}
	}
}