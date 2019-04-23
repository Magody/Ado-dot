using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController {


	public int tier;


	BoxCollider2D boxCollider;
	// Use this for initialization
	void Start () {
		SuperStart ();

		boxCollider = GetComponent<BoxCollider2D> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		boxCollider.enabled = jugadorControlador.JugadorEstado.Esta_atacando && jugadorControlador.Tiene_arma;

		if (jugadorControlador != null) {
			if (tier == 0) {
				danio = 10 + jugadorControlador.JugadorEstadisticas.Fuerza_fisica_actual;  //daño básico de la espada (tier) sumado a la fuerza del jugador
			}
		}
		animatorSetInfo ();
		/*if (last_orientation.x != player_controller.last_move.x || last_orientation.y != player_controller.last_move.y) {
			setOrientation ();	
		}*/
	}

	void animatorSetInfo(){

		if(jugadorControlador.Tiene_arma){
			animator.SetBool ("esta_atacando", jugadorControlador.JugadorEstado.Esta_atacando);
		}
		animator.SetFloat ("direccionX",jugadorControlador.Last_move.x);
		animator.SetFloat ("direccionY",jugadorControlador.Last_move.y);
	}

}
