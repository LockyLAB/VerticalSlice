using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake1 : MonoBehaviour {

	public GameObject Cam;
	private Vector3 _originalPos;
	public float shakeDuration = 1f;
	public float shakeAmount = 1f;

	void Start(){
		_originalPos = Cam.transform.position;
	}
		
	void OnTriggerEnter(){
		Shake (shakeDuration, shakeAmount);
	}



	public void Shake (float shakeDuration, float shakeAmount) {
		this.StopAllCoroutines();
		this.StartCoroutine(cShake(shakeDuration, shakeAmount));
	}

	public IEnumerator cShake (float shakeDuration, float amount) {
		float endTime = Time.time + shakeDuration;
		while (Time.time < endTime) {
			Cam.transform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime;
			yield return null;
		}
		Cam.transform.localPosition = _originalPos;
	}
}
