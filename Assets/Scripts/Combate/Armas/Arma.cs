using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour {

	/*Clase que ofrece herencia para reutilizar codigo*/

	public int tier;


	public const string TIPO_ESPADA = "espada";


	public const string ENCANTAMIENTO_NINGUNO = "ninguno";
	public const string ENCANTAMIENTO_FUEGO = "fuego";
	public const string ENCANTAMIENTO_HIELO = "hielo";
	public const string ENCANTAMIENTO_TRUENO = "trueno";

	protected string tipo;

	protected Animator animator;
	protected float danio;
	protected Jugador jugador;
	protected string encantamiento;

	protected void SuperStart () {
		jugador = ControladorGlobal.jugador;
		animator = GetComponent<Animator> ();

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == ControladorGlobal.STRING_TAG_ENEMIGO && jugador.JugadorEstado.Esta_atacando) {

			float danio_final = danio;
			bool es_critico = ManejadorCombate.esCritico(ControladorGlobal.jugador.JugadorEstadisticas.Critico);
			if (es_critico) {
				danio_final *= 2;
				ControladorGlobal.manejadorSFX.reproducirSFX(ManejadorSFX.SFX_ESPADA_CON_COLISION[Random.Range(0,3)]);
			} else
				ControladorGlobal.manejadorSFX.reproducirSFX(ManejadorSFX.SFX_ESPADA_SIN_COLISION[Random.Range(0,3)]);


			if (encantamiento == ENCANTAMIENTO_FUEGO) {
				danio_final += 10;
			} else if (encantamiento == ENCANTAMIENTO_HIELO) {
				danio_final += 5;
			} else if(encantamiento == ENCANTAMIENTO_TRUENO) {
				danio_final += 15;
			} else if(encantamiento == ENCANTAMIENTO_NINGUNO) {

			} 


			ManejadorCombate.danioFlotanteAlEnemigoPorTrigger(this.transform, jugador.JugadorEstadisticas, col,danio_final, es_critico, jugador.ManejadorHabilidadesPasivas.Tiene_vampirismo);

		}


	}

	public void actualizarDanio(){
		if (tier == 0) {
			danio = 10 + jugador.JugadorEstadisticas.Fuerza_fisica_actual;  //daño básico de la espada (tier) sumado a la fuerza del jugador
		}
	}

	public float Danio {
		get {
			return this.danio;
		}
		set {
			danio = value;
		}
	}

	public string Encantamiento {
		get {
			return this.encantamiento;
		}
		set {
			encantamiento = value;
		}
	}

	public string Tipo {
		get {
			return this.tipo;
		}
		set {
			tipo = value;
		}
	}

}
