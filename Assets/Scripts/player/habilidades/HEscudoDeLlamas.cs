using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEscudoDeLlamas : Habilidad {


	float aumento_defensa = 0.5f;
	float aumento_fuerza_fisica = 0.3f;

	// Use this for initialization
	void Start () {
		SuperStart ();
		nombre = "EscudoDeLlamas";
		prefab_efecto = Resources.Load("Prefabs/habilidades/prefab_escudo_de_llamas") as GameObject;

		costo_mana = 0.5f; //50% del total
		costo_resistencia = 0.5f; //50% del total
		tiempo_duracion_base = 60;
		tiempo_duracion_contador = tiempo_duracion_base;
		tiempo_reutilizacion_base = 180;
		tiempo_reutilizacion_contador = tiempo_reutilizacion_base;


	}

	// Update is called once per frame
	void Update () {

		if (!esta_reutilizacion) {
			if (esta_activada) {


				
				tiempo_duracion_contador -= Time.deltaTime;

				if (tiempo_duracion_contador < 0) {
					esta_activada = false;
					esta_reutilizacion = true;
					tiempo_duracion_contador = tiempo_duracion_base;
					jugadorEstadisticas.actualizarEstadisticasNivel (); //restablece los valores normales
					Destroy(GameObject.Find(prefab_efecto.name+"(Clone)"));
				}


			}
		} else {
			tiempo_reutilizacion_contador -= Time.deltaTime;
			if (tiempo_reutilizacion_contador < 0) {
				esta_reutilizacion = false;
				tiempo_reutilizacion_contador = tiempo_reutilizacion_base;

			}
		}

		/*if (Input.GetKeyUp (KeyCode.Alpha1)) {
			activar ();
		}*/

	}


	public override void activar(){


		if (!esta_activada && jugadorEstadisticas.Mana_actual >= costo_mana*jugadorEstadisticas.Mana_base[jugadorControlador.JugadorEstadisticas.Nivel_actual]
			&& jugadorEstadisticas.Resistencia_actual >= costo_resistencia*jugadorEstadisticas.Resistencia_base[jugadorEstadisticas.Nivel_actual]) {
			jugadorEstadisticas.Mana_actual -= costo_mana*jugadorEstadisticas.Mana_actual;
			jugadorEstadisticas.Resistencia_actual -= costo_resistencia*jugadorEstadisticas.Resistencia_base[jugadorEstadisticas.Nivel_actual];

			jugadorEstadisticas.Vida_actual += jugadorEstadisticas.Vida_actual * aumento_defensa;
			jugadorEstadisticas.Defensa_fisica_actual += jugadorEstadisticas.Defensa_fisica_actual * aumento_defensa;
			jugadorEstadisticas.Defensa_magica_actual += jugadorEstadisticas.Defensa_magica_actual * aumento_defensa;
			jugadorEstadisticas.Bloquear += jugadorEstadisticas.Bloquear * aumento_defensa;
			jugadorEstadisticas.Esquivar += jugadorEstadisticas.Esquivar * aumento_defensa;
			jugadorEstadisticas.Fuerza_fisica_actual += jugadorEstadisticas.Fuerza_fisica_actual * aumento_fuerza_fisica;

			esta_activada = true;
			Instantiate (prefab_efecto, new Vector3(this.transform.position.x,this.transform.position.y, -0.2f), this.transform.rotation);
		}


	}





}