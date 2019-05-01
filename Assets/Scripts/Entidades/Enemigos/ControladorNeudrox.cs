using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNeudrox : Enemigo {


	void Start () {
		SuperStart ();
		tiempo_quieto_contador = Random.Range(tiempo_quieto*0.75f,tiempo_quieto*1.25f);
		tiempo_movimiento_contador = Random.Range(tiempo_movimiento*0.75f,tiempo_movimiento*1.25f);
		prefab_sangre = ControladorGlobal.PREFAB_SANGRE_AZUL;
		danio = 30;
	}

	// Update is called once per frame
	void Update () {
		SuperUpdate ();

		if (ControladorGlobal.flujo_normal_tiempo) {
			if (esta_moviendose) {

				tiempo_movimiento_contador -= Time.deltaTime;

				if (tiempo_movimiento_contador < 0f) {
					esta_moviendose = false;
					rb.velocity = Vector2.zero;
					tiempo_quieto_contador = Random.Range (tiempo_quieto * 0.75f, tiempo_quieto * 1.25f);

				}


			} else {

				tiempo_quieto_contador -= Time.deltaTime;

				if (tiempo_quieto_contador < 0f) {
					esta_moviendose = true;
					direccion_movimiento = new Vector3 (Random.Range (-1, 2) * velocidad_movimiento, Random.Range (-1, 2) * velocidad_movimiento, 0f);
					rb.velocity = direccion_movimiento;
					tiempo_movimiento_contador = Random.Range (tiempo_movimiento * 0.75f, tiempo_movimiento * 1.25f);
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

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == ControladorGlobal.jugador.name) {

			col.gameObject.SendMessageUpwards ("aplicarDanio", new string[]{""+danio,ControladorGlobal.STRING_DANIO_FISICO});

		} 
	}
}
