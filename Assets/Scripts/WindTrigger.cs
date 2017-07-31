using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger : MonoBehaviour {

	WindZone wind;
	PlayerController pc;
	public float windMain = 1f;
	public AudioClip creatureRoar;
	public AudioClip hecticWind;
	public AudioClip heavyBreathing;
	public float windVolume = 1f;
	public float breathingVolume = 1f;
	public float creatureRoarVolume = 1f;
	public GameObject musicBoxWind;
	public GameObject musicBoxDark;
//	public bool isWindy = false;
//	public int counter;

	void Start () {
		wind = GameObject.FindWithTag ("Wind").GetComponent<WindZone> ();
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter(){
		StartCoroutine (Roar ());
//		isWindy = true;
}

	void OntriggerExit(){
		Destroy (this.gameObject);
	}

	private IEnumerator Roar(){
		AudioSource.PlayClipAtPoint (creatureRoar, transform.position, creatureRoarVolume);
		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolume);
		yield return new WaitForSeconds (0.5f);
		musicBoxDark.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		pc.walkSpeed = 0.15f;
		yield return new WaitForSeconds (0.5f);
		musicBoxWind.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		wind.windMain = 8f;



	}

	void Update(){
//		if(isWindy == true){
//			counter++;
//			if(counter > 40){
//				counter = 40;
//				if(counter == 40 && pc.walkSpeed == 0.06f){
//					pc.walkSpeed = 0.18f;
//				}
//			}
//
//		}
	}
}