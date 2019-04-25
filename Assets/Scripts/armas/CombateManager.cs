using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateManager : MonoBehaviour {

	private static GameObject prefab_danio_flotante = Resources.Load ("Prefabs/efectos/prefab_danio_flotante") as GameObject;

	public static void danioFlotante(Transform transform, JugadorEstadisticas jugadorEstadisticas, Collider2D col, float danio){


		var clone = (GameObject) Instantiate (prefab_danio_flotante, transform.position, Quaternion.Euler (Vector3.zero));

		float prob_critico = jugadorEstadisticas.Critico;
		float damage_final = 0;

		if (prob_critico == 0)
			damage_final = danio;
		else if (prob_critico > 0) {
			//se parte de la hipótesis que todos los números tienen igual probabilidad de aparecer
			int random = Random.Range (1,101);
			//asi que si el crítico es de 20 y decimos que hay critico cuando el randómico sea menor a 20
			// decimos que solo tiene 20 de 100 oportunidades de llegar a esos valores

			if (random <= prob_critico) {
				damage_final = danio * 2; //un 100% más de daño
			} else {
				damage_final = danio;
			}

		}

		clone.GetComponent<TextoFlotante> ().texto = ""+damage_final;
		if (damage_final > danio) {
			clone.GetComponent<TextoFlotante> ().Tamanio *= 2;
			clone.GetComponent<TextoFlotante> ().text_numero.color = Color.yellow;
		}

		col.gameObject.SendMessageUpwards ("aplicarDanio", damage_final);

	}

	public static void danioFlotanteColision(Transform transform, JugadorEstadisticas jugadorEstadisticas, Collision2D col, float danio){


		var clone = (GameObject) Instantiate (prefab_danio_flotante, transform.position, Quaternion.Euler (Vector3.zero));

		float prob_critico = jugadorEstadisticas.Critico;
		float damage_final = 0;

		if (prob_critico == 0)
			damage_final = danio;
		else if (prob_critico > 0) {
			//se parte de la hipótesis que todos los números tienen igual probabilidad de aparecer
			int random = Random.Range (1,101);
			//asi que si el crítico es de 20 y decimos que hay critico cuando el randómico sea menor a 20
			// decimos que solo tiene 20 de 100 oportunidades de llegar a esos valores

			if (random <= prob_critico) {
				damage_final = danio * 2; //un 100% más de daño
			} else {
				damage_final = danio;
			}

		}

		clone.GetComponent<TextoFlotante> ().texto = ""+damage_final;
		if (damage_final > danio) {
			clone.GetComponent<TextoFlotante> ().Tamanio *= 2;
			clone.GetComponent<TextoFlotante> ().text_numero.color = Color.yellow;
		}


		col.gameObject.SendMessageUpwards ("aplicarDanio", damage_final);

	}

	public static void sanacionFlotanteJugador(Transform transform, float sanacion, JugadorEstadisticas jugadorEstadisticas){

		jugadorEstadisticas.aplicarSanacion (sanacion);
		var clone = (GameObject) Instantiate (prefab_danio_flotante, transform.position, Quaternion.Euler (Vector3.zero));
		clone.GetComponent<TextoFlotante> ().texto = ""+((float)((int)(sanacion*100))/100);
		clone.GetComponent<TextoFlotante> ().text_numero.color = Color.green;


	}


}
