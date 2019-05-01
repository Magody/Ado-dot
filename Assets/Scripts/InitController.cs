using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitController : MonoBehaviour {

	/*Esta clase controla lo que ocurre la primer decima de segundo cuando se 
	carga una nueva escena. Como pausa,etc.*/


	private Jugador player_controller;
	private bool once;
	private float timer;
	public string musica;

	void Start () {
		once = true;


		ControladorGlobal.manejadorMusica.reproducirMusica (musica);
	}

	void Update(){

		if (once) {

			//print (timer);
			timer += Time.deltaTime;
			if (timer > 0.1f) {
				player_controller = FindObjectOfType<Jugador> ();
				player_controller.Puede_moverse = true;
				once = false;
				Destroy (this.gameObject);
			}


		}

	}

}
