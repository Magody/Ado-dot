using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMoneda : MonoBehaviour {
	/*Empuja en una direccion a la moneda y le activa la colision*/

	private BoxCollider2D boxCollider2D;
	private float valor;
	private float fuerza;
	private float tiempo_movimiento;

	void Start () {
		boxCollider2D = GetComponent<BoxCollider2D> ();
		boxCollider2D.enabled = false;
		fuerza = 20f;
		tiempo_movimiento = 1f; //es para que se separen del cuerpo
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (Random.Range (-1, 2), Random.Range (-1, 2)) * fuerza * Time.deltaTime, ForceMode2D.Impulse);
	}

	void Update(){

		tiempo_movimiento -= Time.deltaTime;

		if (tiempo_movimiento <= 0) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			boxCollider2D.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.gameObject.name == ControladorGlobal.jugador.name) {
			ManejadorDialogos.IniciarDialogo (new string[]{"Has recibido " + valor + " monedas."});
			ControladorGlobal.jugador.Monedas += valor;
			ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_MONEDA);

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
