using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWindTrigger3 : MonoBehaviour {

	public AudioClip creature;
	public float creatureVolume = 1f;
	WindZone wind;

	// Use this for initialization
	void Start () {
		wind = GameObject.FindWithTag ("Wind").GetComponent<WindZone> ();
	}

	void OnTriggerEnter(){
		wind.windMain = 4f;
		AudioSource.PlayClipAtPoint (creature, transform.position, creatureVolume);
	}

	void OnTriggerExit(){
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
