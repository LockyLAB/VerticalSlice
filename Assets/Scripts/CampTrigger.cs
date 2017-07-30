using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampTrigger : MonoBehaviour {

	PlayerController pc;

	public AudioClip creatureGrowl;
	public AudioClip heavyBreathingQuick;
	public AudioClip treeFalling;
	public float creatureGrowlVolume = 1f;
	public float heavyBreathingQuickVolume = 1f;
	public float treeFallingVolume = 1f;

	public float secondsToWaitTreeSounds = 1.5f;
	public float secondsToWaitAnimations = 1f;
	public float secondsToWaitCreatureSounds = 2f;

	public Animator animator;
	public Animator animator2;
	public Animator animator3;
	public Animator animator4;
	//public Animator animator5;*/

	public GameObject birds;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}
		


	void OnTriggerEnter(){
		StartCoroutine (Trees ());
		pc.isWalking = false;
		StartCoroutine (Sounds ());
		StartCoroutine (TreeFallingSounds ());
		birds.SetActive (false);

	}


	private IEnumerator Trees(){
//		animator.SetTrigger("TreeFalling");
//		yield return new WaitForSeconds (secondsToWaitAnimations);
		yield return new WaitForSeconds (1.5f);
		animator2.SetTrigger ("TreeFalling2");
		yield return new WaitForSeconds (secondsToWaitAnimations);
		animator3.SetTrigger ("TreeFalling3");
		yield return new WaitForSeconds (secondsToWaitAnimations);
		animator4.SetTrigger ("TreeFalling4");
//		yield return new WaitForSeconds (secondsToWaitAnimations);
//		animator5.SetTrigger ("TreeFalling5");

	}

	private IEnumerator Sounds(){
//		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (creatureGrowl, transform.position, creatureGrowlVolume);
		yield return new WaitForSeconds (secondsToWaitCreatureSounds);
		AudioSource.PlayClipAtPoint (heavyBreathingQuick, transform.position, heavyBreathingQuickVolume);
	}

	private IEnumerator TreeFallingSounds(){
//		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
//		yield return new WaitForSeconds (secondsToWaitTreeSounds);
		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (secondsToWaitTreeSounds);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (secondsToWaitTreeSounds);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
//		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
//		yield return new WaitForSeconds (secondsToWaitTreeSounds);

	}
}
