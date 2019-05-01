using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorCombate : MonoBehaviour {
	/*Métodos enfocados para Jugador hacia el enemigo*/ 


	public static void danioFlotanteAlEnemigoPorTrigger(Transform transform, JugadorEstadisticas jugadorEstadisticas, Collider2D col, float danio, bool es_critico, bool tiene_vampirismo){


		var clone = (GameObject) Instantiate (ControladorGlobal.PREFAB_TEXTO_FLOTANTE, transform.position, Quaternion.Euler (Vector3.zero));

		clone.GetComponent<TextoFlotante> ().Texto = ""+danio;
		if (es_critico) {
			clone.GetComponent<TextoFlotante> ().Tamanio *= 2;
			clone.GetComponent<TextoFlotante> ().Text.color = Color.yellow;
		}

		col.gameObject.SendMessageUpwards ("aplicarDanio", danio);

		if (tiene_vampirismo) {
			float sanacion = 0.05f * danio;
			jugadorEstadisticas.aplicarSanacion(sanacion);
			Instantiate (ControladorGlobal.PREFAB_VAMPIRISMO,new Vector3(transform.position.x, transform.position.y, -0.2f),transform.rotation);
		}
		



	}

	public static void danioFlotanteAlEnemigoPorCollision(Transform transform, JugadorEstadisticas jugadorEstadisticas, Collision2D col, float danio, bool es_critico, bool tiene_vampirismo){


		var clone = (GameObject) Instantiate (ControladorGlobal.PREFAB_TEXTO_FLOTANTE, transform.position, Quaternion.Euler (Vector3.zero));

		clone.GetComponent<TextoFlotante> ().Texto = ""+danio;
		if (es_critico) {
			clone.GetComponent<TextoFlotante> ().Tamanio *= 2;
			clone.GetComponent<TextoFlotante> ().Text.color = Color.yellow;
		}

		col.gameObject.SendMessageUpwards ("aplicarDanio", danio);

		if (tiene_vampirismo) {
			float sanacion = 0.05f * danio;
			jugadorEstadisticas.aplicarSanacion(sanacion);
			Instantiate (ControladorGlobal.PREFAB_VAMPIRISMO,new Vector3(transform.position.x, transform.position.y, -0.2f),transform.rotation);
		}

	}

	public static void sanacionFlotanteAlJugador(Transform transform, float sanacion, JugadorEstadisticas jugadorEstadisticas, float velocidad){
		//por default usar 2 de velocidad
		jugadorEstadisticas.aplicarSanacion (sanacion);
		var clone = (GameObject) Instantiate (ControladorGlobal.PREFAB_TEXTO_FLOTANTE, transform.position, Quaternion.Euler (Vector3.zero));
		clone.GetComponent<TextoFlotante> ().Texto = ""+((float)((int)(sanacion*100))/100);
		clone.GetComponent<TextoFlotante> ().Text.color = Color.green;
		clone.GetComponent<TextoFlotante> ().Velocidad_movimiento = velocidad;

	}

	public static bool esCritico(float critico){
		return Random.Range (1, 101)  <= critico;
	}


}
