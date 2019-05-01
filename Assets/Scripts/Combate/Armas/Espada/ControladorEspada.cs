using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEspada : Arma {

	/*Se encarga de asignarle collision, daño y animacion a la espada*/



	private BoxCollider2D boxCollider2D;

	void Start () {
		SuperStart ();
		boxCollider2D = GetComponent<BoxCollider2D> ();
		tipo = TIPO_ESPADA;
	}


	void Update () {

		boxCollider2D.enabled = jugador.JugadorEstado.Esta_atacando && jugador.Tiene_arma;

		if (danio < 1) {
			if (tier == 0) {
				danio = 10 + jugador.JugadorEstadisticas.Fuerza_fisica_actual;  //daño básico de la espada (tier) sumado a la fuerza del jugador
			}
		}


		animatorSetInfo ();
	}



	void animatorSetInfo(){

		if(jugador.Tiene_arma){
			animator.SetBool ("esta_atacando", jugador.JugadorEstado.Esta_atacando);
		}
		animator.SetFloat ("direccionX",jugador.AxisUltimo.x);
		animator.SetFloat ("direccionY",jugador.AxisUltimo.y);
	}

}
