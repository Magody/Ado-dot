using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource SOUND_JUGADOR_HERIDO;
	public AudioSource SOUND_JUGADOR_ATAQUE;

	public static bool soundManager_exist;

	// Use this for initialization
	void Start () {
		
		if (!SoundManager.soundManager_exist) {
			SoundManager.soundManager_exist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
