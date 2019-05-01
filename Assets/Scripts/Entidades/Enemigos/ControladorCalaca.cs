using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCalaca : Enemigo{


	void Start () {
		SuperStart ();
		tiempo_quieto_contador = Random.Range(tiempo_quieto*0.75f,tiempo_quieto*1.25f);
		tiempo_movimiento_contador = Random.Range(tiempo_movimiento*0.75f,tiempo_movimiento*1.25f);
		prefab_sangre = ControladorGlobal.PREFAB_SANGRE_BLANCA;
		danio = 150;
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

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.name == ControladorGlobal.jugador.name) {

			collision.gameObject.SendMessageUpwards ("aplicarDanio", new string[]{""+danio,ControladorGlobal.STRING_DANIO_MAGICO});

		} 
	}
}
