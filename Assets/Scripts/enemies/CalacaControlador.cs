using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalacaControlador : EnemyController{


	void Start () {
		SuperStart ();
		time_pause_move_counter = Random.Range(time_pause_move*0.75f,time_pause_move*1.25f);
		time_moving_counter = Random.Range(time_moving*0.75f,time_moving*1.25f);
		jugador = GameObject.FindGameObjectWithTag ("Player").name;
		danio = 150;
	}

	// Update is called once per frame
	void Update () {
		SuperUpdate ();

		if (ControladorGlobal.flujo_normal_tiempo) {


			if (esta_moviendose) {

				time_moving_counter -= Time.deltaTime;

				if (time_moving_counter < 0f) {
					esta_moviendose = false;
					rb.velocity = Vector2.zero;
					time_pause_move_counter = Random.Range (time_pause_move * 0.75f, time_pause_move * 1.25f);
				}


			} else {

				time_pause_move_counter -= Time.deltaTime;

				if (time_pause_move_counter < 0f) {
					esta_moviendose = true;
					direccion_movimiento = new Vector3 (Random.Range (-1, 2) * velocidad_movimiento, Random.Range (-1, 2) * velocidad_movimiento, 0f);
					rb.velocity = direccion_movimiento;
					time_moving_counter = Random.Range (time_moving * 0.75f, time_moving * 1.25f);
					animator.SetFloat ("direccionX", direccion_movimiento.x / velocidad_movimiento);
					animator.SetFloat ("direccionY", direccion_movimiento.y / velocidad_movimiento);
				}
				if (!detener_animacion) {
					animator.enabled = true;
					detener_animacion = true;
				}



			}

		} else {
			detenerTiempoPropio ();
			dibujarBarraVida ();
		}

		animator.SetBool ("esta_moviendose",esta_moviendose);


	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == jugador) {

			col.gameObject.SendMessageUpwards ("aplicarDanio", new string[]{""+danio,"magico"});

		} 
	}
}
