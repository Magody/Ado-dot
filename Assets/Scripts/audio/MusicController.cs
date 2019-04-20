using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {



	public static bool musicController_exist;
	public AudioSource[] musicas;
	public int musica_actual;
	public bool musica_puede_sonar;

	// Use this for initialization
	void Start () {
		if (!MusicController.musicController_exist) {
			MusicController.musicController_exist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (musica_puede_sonar) {
			if (!musicas [musica_actual].isPlaying) {
				musicas [musica_actual].Play ();
			}
				
		} else {
			musicas [musica_actual].Stop ();
		}
	}

	public void cambiarMusica(int nueva_cancion){
		musicas [musica_actual].Stop ();
		musica_actual = nueva_cancion;
		musicas [musica_actual].Play ();
	}

}
