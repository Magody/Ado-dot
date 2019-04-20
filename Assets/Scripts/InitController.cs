using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour {

	/*Esta clase controla lo que ocurre la primer decima de segundo cuando se 
	carga una nueva escena. Como pausa,etc.*/


	private JugadorControlador player_controller;
	private bool once;
	private float timer;
	public int musica;
	MusicController musicController;
	void Start () {
		once = true;
		musicController = FindObjectOfType<MusicController> ();
		musicController.cambiarMusica (musica);
	}

	void Update(){

		if (once) {

			//print (timer);
			timer += Time.deltaTime;
			if (timer > 0.1f) {
				player_controller = FindObjectOfType<JugadorControlador> ();
				player_controller.Can_move = true;
				once = false;
				Destroy (this.gameObject);
			}


		}

	}

}
