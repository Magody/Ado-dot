using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaControlador : MonoBehaviour {

	JugadorControlador jugadorControlador;
	float valor;
	private float fuerza;
	private float tiempo_movimiento;
	BoxCollider2D boxCollider2D;
	// Use this for initialization
	void Start () {
		boxCollider2D = GetComponent<BoxCollider2D> ();
		boxCollider2D.enabled = false;
		fuerza = 20f;
		tiempo_movimiento = 1f;
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (Random.Range (-1, 2), Random.Range (-1, 2)) * fuerza * Time.deltaTime, ForceMode2D.Impulse);
	}

	void Update(){

		tiempo_movimiento -= Time.deltaTime;

		if (tiempo_movimiento <= 0) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			boxCollider2D.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == jugadorControlador.name) {
			DialogManager.IniciarDialogo (new string[]{"Has recibido " + valor + " monedas."});
			jugadorControlador.Monedas += valor;
			Destroy (this.gameObject);
		}
	}

	public float Valor {
		get {
			return this.valor;
		}
		set {
			valor = value;
		}
	}
}
