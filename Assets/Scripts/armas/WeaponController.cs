using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour {

	protected JugadorControlador jugadorControlador;
	protected Animator animator;
	public float danio;
	public GameObject prefab_danio_flotante;

	// Use this for initialization
	protected void SuperStart () {
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy" && jugadorControlador.JugadorEstado.Esta_atacando) {

			CombateManager.danioFlotante(this.transform, jugadorControlador.JugadorEstadisticas, col,danio, jugadorControlador.habilidades_pasivas.Tiene_vampirismo);

		}


	}

}
