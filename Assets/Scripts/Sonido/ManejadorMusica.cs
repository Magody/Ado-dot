using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorMusica : MonoBehaviour {



	public static bool musicController_exist;
	public static AudioSource audioSource;
	public static AudioClip musicaAnterior;
	public static AudioClip MUSICA_CIUDAD;
	public static AudioClip MUSICA_TIEMPO_DETENIDO;

	public static bool musica_puede_sonar;

	// Use this for initialization
	void Start () {
		if (!ManejadorMusica.musicController_exist) {
			ManejadorMusica.musicController_exist = true;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (this.gameObject);
		}
		audioSource = GetComponent<AudioSource> ();
		MUSICA_CIUDAD = Resources.Load ("Sonido/Musica/TownTheme") as AudioClip;
		MUSICA_TIEMPO_DETENIDO = Resources.Load ("Sonido/Musica/Heavenly Loop") as AudioClip;
	}

	public void reproducirMusica(string nuevoClip){
		if (!audioSource.isPlaying) {
			
			audioSource.clip = Resources.Load ("Sonido/Musica/" + nuevoClip) as AudioClip;
			musicaAnterior = audioSource.clip;
			audioSource.Play ();
		}
	}

	public void detenerMusica(){
		audioSource.Stop ();
	}

	public void cambiarMusica(AudioClip nuevoClip){
		musicaAnterior = audioSource.clip;
		audioSource.Stop ();
		audioSource.clip = nuevoClip;
		audioSource.Play ();
	}

	public void cambiarMusica(string nuevoClip){
		/*nuevoClip no debe tener extension*/
		musicaAnterior = audioSource.clip;
		audioSource.Stop ();
		audioSource.clip = Resources.Load ("Sonido/Musica/"+nuevoClip) as AudioClip;
		audioSource.Play ();
	}

}
