using System.Collections;
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
		AudioSource.PlayClipAtPoint (creature, transform.position, creatureVolume);
		wind.windMain = 7f;
		StartCoroutine (FloodLights ());
	
	}

	private IEnumerator FloodLights (){
		animator.SetTrigger ("LightScramble");
		yield return new WaitForSeconds (1f);
		lightGuideR.SetActive (true);
		yield return new WaitForSeconds (1f);
		lightGuideL.SetActive (true);
	}


	void OntriggerExit(){
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
