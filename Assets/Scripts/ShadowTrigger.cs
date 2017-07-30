using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTrigger : MonoBehaviour {

	public Animator animator; 
	public GameObject shadow;

	void OnTriggerEnter(){
		StartCoroutine (Shadow ());
	}

	private IEnumerator Shadow(){
		shadow.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		animator.SetTrigger ("ShadowMove");
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}
}