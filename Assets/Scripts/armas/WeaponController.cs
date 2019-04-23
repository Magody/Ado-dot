using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour {

	protected JugadorControlador jugadorControlador;
	protected Animator animator;
	public float danio;
	public GameObject prefab_danio_flotante;

	// Use this for initialization
	protected void SuperStart () {
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected void SuperUpdate () {
		
	}



	public static void danioFlotante(GameObject prefab_danio_flotante, Transform transform, JugadorEstadisticas jugadorEstadisticas, Collider2D col, float danio){


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

		col.gameObject.SendMessageUpwards ("applyDamage", damage_final);

	}

	//public abstract void setOrientation ();

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy" && jugadorControlador.JugadorEstado.Esta_atacando) {

			WeaponController.danioFlotante(prefab_danio_flotante, this.transform, jugadorControlador.JugadorEstadisticas, col,danio);

		}


	}

}
