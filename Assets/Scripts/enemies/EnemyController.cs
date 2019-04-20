using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

	public float move_speed;
	protected Rigidbody2D rb;
	protected bool is_moving;
	protected Vector3 move_direction;

	public float vida_base;
	public float vida_actual;
	public int exp_recompensa;

	private JugadorControlador jugadorControlador;


	public GameObject particle_prefab_blood;




	// Use this for initialization
	protected void SuperStart () {
		rb = GetComponent<Rigidbody2D> ();
		vida_actual = vida_base;
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
	}
	
	// Update is called once per frame
	protected void SuperUpdate () {
		if (vida_actual <= 0) {
			jugadorControlador.JugadorEstadisticas.Experiencia_actual += exp_recompensa;
			QuestManager.ultimo_enemigo_asesinado = gameObject.name;
			Destroy (this.gameObject);
		}
	}

	void applyDamage(float damage){
		if (vida_actual - damage >= 0)
			vida_actual -= damage;
		else 
			vida_actual = 0;

		Instantiate (particle_prefab_blood, transform.position,transform.rotation);

	}


}
