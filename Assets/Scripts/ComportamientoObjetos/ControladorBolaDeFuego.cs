using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBolaDeFuego : MonoBehaviour {

	/*establece la velocidad, tiempo de vida y tiempo entre ataques del collision-stay*/

	private Vector2 direccion;
	private int velocidad;
	private float tiempo_danio;
	private float tiempo_danio_contador; //son los intervalos en que produce daño, sino fuera por esto meteria mil de daño en un segundo
	private float tiempo_vida;


	public void Start(){
		tiempo_vida = 5f;
		velocidad = 3;
		tiempo_danio_contador = 0.3f;
		GetComponent<Rigidbody2D> ().velocity = direccion*velocidad;
		tiempo_danio = tiempo_danio_contador;
		Destroy (this.gameObject, tiempo_vida);
	}

	void OnCollisionStay2D(Collision2D collision){
		
		if (collision.gameObject.tag != ControladorGlobal.STRING_TAG_MAPA) {


			tiempo_danio_contador += Time.deltaTime;

			if (tiempo_danio_contador >tiempo_danio) {

				if (collision.gameObject.tag == ControladorGlobal.STRING_TAG_ENEMIGO) {
					float danio = ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_magica_destructora_actual;

					bool es_critico = ManejadorCombate.esCritico (ControladorGlobal.jugador.JugadorEstadisticas.Critico);
					if (es_critico)
						danio *= 2;

					ManejadorCombate.danioFlotanteAlEnemigoPorCollision (this.transform, ControladorGlobal.jugador.JugadorEstadisticas, collision, danio, es_critico, ControladorGlobal.jugador.ManejadorHabilidadesPasivas.Tiene_vampirismo);
				} 
				tiempo_danio_contador = 0;
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
