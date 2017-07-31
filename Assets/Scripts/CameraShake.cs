using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public float maxSpeed;

	private bool isShaking;

	public void Shake(float duration, float magnitude) {
		if (isShaking) {
			StopCoroutine(StartShake(duration, magnitude));
			isShaking = false;
		}

		StartCoroutine(StartShake(duration, magnitude));
	}

	IEnumerator StartShake(float duration, float magnitude) {
		isShaking = true;
		float elapsed = 0.0f;

		Vector3 originalCamPos = transform.position;

		while (elapsed < duration) {

			elapsed += Time.unscaledDeltaTime;

			float percentComplete = elapsed / duration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;

			transform.position = new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		transform.position = originalCamPos;
		isShaking = false;
	}
}
