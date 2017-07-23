using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreWindTrigger1 : MonoBehaviour {


	WindZone wind;

	// Use this for initialization
	void Start () {
		wind = GameObject.FindWithTag ("Wind").GetComponent<WindZone> ();
	}

	void OnTriggerEnter(){
		wind.windMain = 1.5f;

	}

	// Update is called once per frame
	void Update () {
		
	}
}
