using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour {

	protected JugadorControlador player_controller;
	protected Animator animator;
	public float damage;
	public GameObject prefab_danio_flotante;

	// Use this for initialization
	protected void SuperStart () {
		player_controller = FindObjectOfType<JugadorControlador> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected void SuperUpdate () {
		
	}

	//public abstract void setOrientation ();

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Enemy" && player_controller.JugadorEstado.estado_actual == JugadorEstado.ATACANDO) {


			var clone = (GameObject) Instantiate (prefab_danio_flotante, transform.position, Quaternion.Euler (Vector3.zero));


			float prob_critico = player_controller.JugadorEstadisticas.Critico;

			float damage_final = 0;

			if (prob_critico == 0)
				damage_final = damage;
			else if (prob_critico > 0) {
				//se parte de la hipótesis que todos los números tienen igual probabilidad de aparecer
				int random = Random.Range (1,101);
				//asi que si el crítico es de 20 y decimos que hay critico cuando el randómico sea menor a 20
				// decimos que solo tiene 20 de 100 oportunidades de llegar a esos valores

				if (random <= prob_critico) {
					damage_final = damage * 2; //un 100% más de daño
				} else {
					damage_final = damage;
				}
					
			}

			clone.GetComponent<NumerosFlotantes> ().numero = damage_final;
			if (damage_final > damage) {
				clone.GetComponent<NumerosFlotantes> ().Tamanio *= 2;
				clone.GetComponent<NumerosFlotantes> ().text_numero.color = Color.yellow;
			}

			col.gameObject.SendMessageUpwards ("applyDamage", damage_final);
			print ("El arma golpeo a " + col.gameObject.name);


		}


	}

}
