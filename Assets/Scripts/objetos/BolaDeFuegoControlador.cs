using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuegoControlador : MonoBehaviour {

	public GameObject prefab_danio_flotante;
	JugadorControlador jugadorControlador;
	Vector2 direccion;
	float tiempo_danio;
	float tiempo_vida;
	float intervalo_danio;
	int velocidad;

	public void Start(){
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		tiempo_vida = 5f;
		velocidad = 3;
		intervalo_danio = 0.3f;
		GetComponent<Rigidbody2D> ().velocity = direccion*velocidad;
		tiempo_danio = intervalo_danio;
		Destroy (this.gameObject, tiempo_vida);
	}

	void OnCollisionStay2D(Collision2D col){
		
		if (col.gameObject.tag != "mapa") {


			tiempo_danio += Time.deltaTime;

			if (tiempo_danio >intervalo_danio) {

				if (col.gameObject.tag == "Enemy") {
					float danio = jugadorControlador.JugadorEstadisticas.Fuerza_magica_destructora_actual;
					CombateManager.danioFlotanteColision (this.transform, jugadorControlador.JugadorEstadisticas, col, danio, jugadorControlador.habilidades_pasivas.Tiene_vampirismo);
				} 
				tiempo_danio = 0;
			}

		}
	}

	public Vector2 Direccion {
		get {
			return this.direccion;
		}
		set {
			direccion = value;
		}
	}

}
