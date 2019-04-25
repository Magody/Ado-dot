using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEsperanza : Habilidad {

	float tiempo_segundo_contador;

	void Start () {
		SuperStart ();
		nombre = "Esperanza";
		prefab_efecto = Resources.Load("Prefabs/habilidades/prefab_esperanza") as GameObject;

		costo_mana = 25;
		tiempo_duracion_base = 10;
		tiempo_duracion_contador = tiempo_duracion_base;
		tiempo_reutilizacion_base = 5;
		tiempo_reutilizacion_contador = tiempo_reutilizacion_base;
		tiempo_segundo_contador = 1;


	}

	// Update is called once per frame
	void Update () {

		//print (tiempo_duracion_contador + " duracion/segundo " + tiempo_segundo_contador);

		if (!esta_reutilizacion) {
			if (esta_activada) {


				tiempo_duracion_contador -= Time.deltaTime;
				tiempo_segundo_contador += Time.deltaTime;

				if (tiempo_segundo_contador > 1) {
					CombateManager.sanacionFlotanteJugador (this.transform, jugadorEstadisticas.Vida_base [jugadorEstadisticas.Nivel_actual] * 0.01f, jugadorEstadisticas); //1%
					Instantiate (prefab_efecto, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f), this.transform.rotation);

					tiempo_segundo_contador = 0;
				}

				if (tiempo_duracion_contador < 0) {
					
					esta_activada = false;
					esta_reutilizacion = true;
					tiempo_duracion_contador = tiempo_duracion_base;
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

		if (!esta_activada && jugadorControlador.JugadorEstadisticas.Mana_actual >= costo_mana) {
			jugadorControlador.JugadorEstadisticas.Mana_actual -= costo_mana;
			esta_activada = true;
		}


	}

}