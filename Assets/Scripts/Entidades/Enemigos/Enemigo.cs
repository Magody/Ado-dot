using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour {

	public float vida_base;
	public float vida_actual;
	public int exp_recompensa;
	public int dinero_recompensa;
	public float velocidad_movimiento;
	public Image barra_vida;

	public float tiempo_quieto;
	protected float tiempo_quieto_contador;
	public float tiempo_movimiento;
	protected float tiempo_movimiento_contador;

	protected SpriteRenderer spriteRenderer;
	protected Sprite spriteUltimo;
	protected Vector3 direccion_movimiento;
	protected GameObject prefab_sangre;
	protected Animator animator;
	protected Rigidbody2D rb;
	protected bool esta_moviendose;
	protected float danio;
	protected bool detener_animacion;



	protected void SuperStart () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		vida_actual = vida_base;
		esta_moviendose = true;
		detener_animacion = true;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	protected void SuperUpdate () {
		if (vida_actual <= 0) {
			ControladorGlobal.jugador.JugadorEstadisticas.Experiencia_actual += exp_recompensa;
			ManejadorMisiones.ultimo_enemigo_asesinado = gameObject.name;


			var clone = (GameObject) Instantiate(ControladorGlobal.PREFAB_MONEDA, this.transform.position, this.transform.rotation);
			clone.GetComponent<ControladorMoneda>().Valor = dinero_recompensa;


			Destroy (this.gameObject);
		}

		dibujarBarraVida ();



	}

	protected void dibujarBarraVida(){
		barra_vida.fillAmount = vida_actual / vida_base;
	}

	void aplicarDanio(float damage){
		if (vida_actual - damage >= 0)
			vida_actual -= damage;
		else 
			vida_actual = 0;

		Instantiate (prefab_sangre, transform.position,transform.rotation);

	}

	protected void detenerTiempoPropio(){
		if (detener_animacion) {
			rb.velocity = Vector2.zero;
			esta_moviendose = false;
			spriteUltimo = spriteRenderer.sprite;
			animator.enabled = false;
			detener_animacion = false;
		}



	}


}
