using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOrbe : MonoBehaviour {
	/*Empuja en una direccion al orbe y le activa la colision*/

	private CircleCollider2D circleCollider2D;
	private float fuerza;
	private float tiempo_movimiento;


	void Start () {
		circleCollider2D = GetComponent<CircleCollider2D> ();
		circleCollider2D.enabled = false;
		fuerza = 20f;
		tiempo_movimiento = 1f;
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (Random.Range (-1, 2), Random.Range (-1, 2)) * fuerza * Time.deltaTime, ForceMode2D.Impulse);
	}

	void Update(){

		tiempo_movimiento -= Time.deltaTime;

		if (tiempo_movimiento <= 0) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			circleCollider2D.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == ControladorGlobal.jugador.name) {
			ManejadorDialogos.IniciarDialogo (Mensajes.MSG_ALMA_DE_ENTRENAMIENTO_CONSEGUIDA);
			ControladorGlobal.jugador.ManejadorDestrezas.entrenar ();
			Destroy (this.gameObject);
		}
	}


}
