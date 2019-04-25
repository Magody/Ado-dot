using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

	public float velocidad_movimiento;
	protected Rigidbody2D rb;
	protected bool esta_moviendose;
	protected Vector3 direccion_movimiento;

	public float vida_base;
	public float vida_actual;
	public int exp_recompensa;
	public int dinero_recompensa;

	private JugadorControlador jugadorControlador;

	protected Animator animator;

	public GameObject particle_prefab_blood;
	public GameObject moneda;

	protected float danio;
	public Image barra_vida;


	// Use this for initialization
	protected void SuperStart () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		vida_actual = vida_base;
		jugadorControlador = FindObjectOfType<JugadorControlador> ();

	
	}
	
	// Update is called once per frame
	protected void SuperUpdate () {
		if (vida_actual <= 0) {
			jugadorControlador.JugadorEstadisticas.Experiencia_actual += exp_recompensa;
			QuestManager.ultimo_enemigo_asesinado = gameObject.name;


			var clone = (GameObject) Instantiate(moneda, this.transform.position, this.transform.rotation);
			clone.GetComponent<MonedaControlador>().Valor = dinero_recompensa;


			Destroy (this.gameObject);
		}


		barra_vida.fillAmount = vida_actual / vida_base;


	}

	void aplicarDanio(float damage){
		if (vida_actual - damage >= 0)
			vida_actual -= damage;
		else 
			vida_actual = 0;

		Instantiate (particle_prefab_blood, transform.position,transform.rotation);

	}


}
