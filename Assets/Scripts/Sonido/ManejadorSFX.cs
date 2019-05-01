using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorSFX : MonoBehaviour {

	public static bool existe_manejadorSFX;
	public static AudioSource audioSource;

	public static AudioClip[] SFX_GOLPES;
	public static AudioClip[] SFX_ESPADA_SIN_COLISION;
	public static AudioClip[] SFX_ESPADA_CON_COLISION;
	public static AudioClip SFX_NO_PERMITIDO;
	public static AudioClip SFX_JUGADOR_HERIDO;
	public static AudioClip SFX_BOLA_DE_FUEGO;
	public static AudioClip SFX_CURACION;
	public static AudioClip SFX_MONEDA;

	void Start () {
		if (!ManejadorSFX.existe_manejadorSFX) {
			ManejadorSFX.existe_manejadorSFX = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}
		audioSource = GetComponent<AudioSource> ();
		SFX_GOLPES = new AudioClip[3];
		SFX_GOLPES [0] = Resources.Load ("Sonido/Efectos/hit01") as AudioClip;
		SFX_GOLPES [1] = Resources.Load ("Sonido/Efectos/hit02") as AudioClip;
		SFX_GOLPES [2] = Resources.Load ("Sonido/Efectos/hit03") as AudioClip;
		SFX_NO_PERMITIDO = Resources.Load ("Sonido/Efectos/confusion") as AudioClip;
		SFX_ESPADA_SIN_COLISION = new AudioClip[3];
		SFX_ESPADA_SIN_COLISION [0] = Resources.Load ("Sonido/Efectos/Espada/swing") as AudioClip;
		SFX_ESPADA_SIN_COLISION [1] = Resources.Load ("Sonido/Efectos/Espada/swing2") as AudioClip;
		SFX_ESPADA_SIN_COLISION [2] = Resources.Load ("Sonido/Efectos/Espada/swing3") as AudioClip;
		SFX_ESPADA_CON_COLISION = new AudioClip[3];
		SFX_ESPADA_CON_COLISION [0] = Resources.Load ("Sonido/Efectos/Espada/sword-unsheathe") as AudioClip;
		SFX_ESPADA_CON_COLISION [1] = Resources.Load ("Sonido/Efectos/Espada/sword-unsheathe2") as AudioClip;
		SFX_ESPADA_CON_COLISION [2] = Resources.Load ("Sonido/Efectos/Espada/sword-unsheathe3") as AudioClip;
		SFX_JUGADOR_HERIDO  = Resources.Load ("Sonido/Efectos/hurt") as AudioClip;
		SFX_BOLA_DE_FUEGO  = Resources.Load ("Sonido/Efectos/Hechizos/fireball01") as AudioClip;
		SFX_CURACION  = Resources.Load ("Sonido/Efectos/Hechizos/blessing2") as AudioClip;
		SFX_MONEDA = Resources.Load ("Sonido/Efectos/Objetos/Coin01") as AudioClip;

	}

	public void reproducirSFX(AudioClip clip){
		
		audioSource.clip = clip;
		audioSource.Play ();
	}
		
}
