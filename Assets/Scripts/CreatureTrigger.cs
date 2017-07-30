using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTrigger : MonoBehaviour {
	
	public AudioClip creatureSound;
	public AudioClip heavyBreathing;
	public AudioClip treeFalling;
	public float creatureVolumeLevel = 1f;
	public float breathingVolumeLevel = 1f;
	public float treeFallingVolumeLevel = 1f;
	public GameObject musicBoxBacking;
	public ParticleSystem dustCloud;

	PlayerController pc;

	public Animator animator;


	void Start (){
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter(){
		StartCoroutine (Creature ());
		}

	void OnTriggerExit(){
		animator.SetTrigger ("PathTreeFalling");
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolumeLevel);
		StartCoroutine (Dust ());
		pc.walkSpeed = 0.08f;

	}

	private IEnumerator Creature (){
		AudioSource.PlayClipAtPoint (creatureSound, transform.position, creatureVolumeLevel);
		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolumeLevel);
		yield return new WaitForSeconds (0.5f);
	

	}

	private IEnumerator Dust(){
		
		//yield return new WaitForSeconds (0.1f);

		yield return new WaitForSeconds (1.5f);
		dustCloud.Play ();
		musicBoxBacking.SetActive (false);
		//yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
	}


}
