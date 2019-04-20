using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time2Destroy : MonoBehaviour {

	public float time2destroy;

	void Update () {
		time2destroy -= Time.deltaTime;

		if (time2destroy < 0) {
			Destroy (gameObject);
		}
	}
}
