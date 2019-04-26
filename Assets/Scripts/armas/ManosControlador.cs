using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManosControlador : MonoBehaviour {

	public GameObject prefab_danio_flotante;
	float danio;
	private JugadorControlador jugadorControlador;
	private JugadorEstadisticas jugadorEstadisticas;
	// Use this for initialization
	void Start () {
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		jugadorEstadisticas = FindObjectOfType<JugadorControlador> ().JugadorEstadisticas;
	}


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy") {
			danio = jugadorEstadisticas.Fuerza_fisica_actual;
			CombateManager.danioFlotante(this.transform, jugadorEstadisticas, col,danio, jugadorControlador.habilidades_pasivas.Tiene_vampirismo);


			if (jugadorControlador.Destrezas.Esta_entrenando && jugadorControlador.Destrezas.Tema_entrenamiento == "FF") {

				int aleatorio = Random.Range (1, 191);

				if(aleatorio == 2) //1% prob de entrenar con puño
					jugadorControlador.Destrezas.entrenar ();
			}

		}


	}



}
