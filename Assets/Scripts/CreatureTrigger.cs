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

//	public CameraShake cameraParent;
//	public float shakeDuration = 1f;
//	public float shakeMagnitude = 1f;

//	public GameObject Cam;
//	private Vector3 _originalPos;
//	public float shakeDuration = 1f;
//	public float shakeAmount = 1f;


	PlayerController pc;

	public Animator animator;


	void Start (){
		pc = GameObject.FindWithTag ("Player").GetComponent<PlayerController>();
//		_originalPos = Cam.transform.position;

	}

	void OnTriggerEnter(){
		StartCoroutine (Creature ());
		}

	void OnTriggerExit(){
		animator.SetTrigger ("PathTreeFalling");
		AudioSource.PlayClipAtPoint (treeFalling, transform.position, treeFallingVolumeLevel);
		StartCoroutine (Dust ());
//		cameraParent.Shake (shakeDuration, shakeMagnitude);
		pc.walkSpeed = 0.07f;

	}

	private IEnumerator Creature (){
		AudioSource.PlayClipAtPoint (creatureSound, transform.position, creatureVolumeLevel);
		yield return new WaitForSeconds (1.5f);
		AudioSource.PlayClipAtPoint (heavyBreathing, transform.position, breathingVolumeLevel);
		yield return new WaitForSeconds (0.5f);
	

	}

	private IEnumerator Dust(){
		yield return new WaitForSeconds (1.5f);
		dustCloud.Play ();
		musicBoxBacking.SetActive (false);
		Destroy (this.gameObject);
	}

//	public void Shake (float shakeDuration, float shakeAmount) {
//		this.StopAllCoroutines();
//		this.StartCoroutine(cShake(shakeDuration, shakeAmount));
//	}
//
//	public IEnumerator cShake (float shakeDuration, float amount) {
//		float endTime = Time.time + shakeDuration;
//		while (Time.time < endTime) {
//			Cam.transform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
//			shakeDuration -= Time.deltaTime;
//			yield return null;
//		}
//		Cam.transform.localPosition = _originalPos;
//	}

}
