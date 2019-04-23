using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeControlador : MonoBehaviour {


	JugadorControlador jugadorControlador;
	private float fuerza;
	private float tiempo_movimiento;
	CircleCollider2D circleCollider2D;

	// Use this for initialization
	void Start () {
		circleCollider2D = GetComponent<CircleCollider2D> ();
		circleCollider2D.enabled = false;
		fuerza = 20f;
		tiempo_movimiento = 1f;
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
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

		if (col.gameObject.name == jugadorControlador.name) {
			DialogManager.IniciarDialogo (new string[]{"Has recibido un alma de entrenamiento"});
			jugadorControlador.Destrezas.entrenar ();
			Destroy (this.gameObject);
		}
	}


}
