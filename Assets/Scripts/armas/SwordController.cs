using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController {


	public int tier;


	private Vector2 last_orientation;

	BoxCollider2D boxCollider;
	// Use this for initialization
	void Start () {
		SuperStart ();

		boxCollider = GetComponent<BoxCollider2D> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		boxCollider.enabled = player_controller.JugadorEstado.Esta_atacando;

		if (player_controller != null) {
			if (tier == 0) {
				damage = 1 + player_controller.JugadorEstadisticas.Fuerza_fisica_actual;  //daño básico de la espada (tier) sumado a la fuerza del jugador
			}
		}
		animatorSetInfo ();
		/*if (last_orientation.x != player_controller.last_move.x || last_orientation.y != player_controller.last_move.y) {
			setOrientation ();	
		}*/
	}

	void animatorSetInfo(){
		
		animator.SetBool ("esta_atacando", player_controller.JugadorEstado.Esta_atacando);
		animator.SetFloat ("direccionX",player_controller.Last_move.x);
		animator.SetFloat ("direccionY",player_controller.Last_move.y);
	}

}
