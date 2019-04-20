using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController {


	public int tier;


	private Vector2 last_orientation;
	// Use this for initialization
	void Start () {
		SuperStart ();



		
	}
	
	// Update is called once per frame
	void Update () {

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
		
		animator.SetBool ("esta_atacando", player_controller.JugadorEstado.Estado_actual == JugadorEstado.ATACANDO);
		animator.SetFloat ("direccionX",player_controller.Last_move.x);
		animator.SetFloat ("direccionY",player_controller.Last_move.y);
	}

}
