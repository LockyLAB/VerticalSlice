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

	public float secondsBetweenSounds = 1.5f;
	public float secondsBetweenAnimations = 1f;
	public float secondsBetweenCreatureSounds = 2f;
	public float secondsBetweenDust2 = 1f;
	public float secondsBetweenDust3 = 1f;
	public float secondsBetweenDust4 = 1f;



	public Animator animator2;
	public Animator animator3;
	public Animator animator4;
	public Animator animator5;
	//public Animator animator5;*/

	public ParticleSystem dustCloud2;
	public ParticleSystem dustCloud3;
	public ParticleSystem dustCloud4;

	public GameObject birds;


	// Use this for initialization
	void Start () {
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}
		


	void OnTriggerEnter(){
		StartCoroutine (Trees ());
		pc.isWalking = false;
		StartCoroutine (Sounds ());
		StartCoroutine (TreeFallingSounds ());
		StartCoroutine (DustClouds ());
		birds.SetActive (false);

	}


	private IEnumerator Trees(){
//		animator.SetTrigger("TreeFalling");
//		yield return new WaitForSeconds (secondsToWaitAnimations);
		yield return new WaitForSeconds (1.5f);
		animator2.SetTrigger ("TreeFalling2");
		yield return new WaitForSeconds (secondsBetweenAnimations);
		animator3.SetTrigger ("TreeFalling3");
		yield return new WaitForSeconds (secondsBetweenAnimations);
		animator4.SetTrigger ("TreeFalling4");
		yield return new WaitForSeconds (1F);
		animator5.SetTrigger ("FadeOut");


//		yield return new WaitForSeconds (secondsToWaitAnimations);
//		animator5.SetTrigger ("TreeFalling5");

	}

	private IEnumerator Sounds(){
//		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (creatureGrowl, transform.position, creatureGrowlVolume);
		yield return new WaitForSeconds (secondsBetweenCreatureSounds);
		AudioSource.PlayClipAtPoint (heavyBreathingQuick, transform.position, heavyBreathingQuickVolume);
	}

	private IEnumerator TreeFallingSounds(){
//		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
//		yield return new WaitForSeconds (secondsToWaitTreeSounds);
		yield return new WaitForSeconds (1.3f);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (secondsBetweenSounds);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (secondsBetweenSounds);
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
		yield return new WaitForSeconds (5f);
		Application.Quit ();
//		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolume);
//		yield return new WaitForSeconds (secondsToWaitTreeSounds);

	}

	private IEnumerator DustClouds (){
		yield return new WaitForSeconds (secondsBetweenDust2);
		dustCloud2.Play ();
		yield return new WaitForSeconds (secondsBetweenDust3);
		dustCloud3.Play ();
		yield return new WaitForSeconds (secondsBetweenDust4);
		dustCloud4.Play ();
	}
}
