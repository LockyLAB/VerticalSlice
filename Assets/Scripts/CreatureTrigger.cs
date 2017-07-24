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

	PlayerController pc;

	public Animator animator;


	void Start (){
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter(){
		StartCoroutine (Creature ());
		}

	void OnTriggerExit(){
		pc.walkSpeed = 0.08f;
		animator.SetTrigger ("PathTreeFalling");
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolumeLevel);
		Destroy (this.gameObject);
	}

	private IEnumerator Creature (){
		AudioSource.PlayClipAtPoint (creatureSound, transform.position, creatureVolumeLevel);
		yield return new WaitForSeconds (1f);
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolumeLevel);
	}



}
