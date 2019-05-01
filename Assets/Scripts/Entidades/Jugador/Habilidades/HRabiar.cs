using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRabiar : Habilidad {

	float valor_inicial_FMD, valor_inicial_FF;

	void Start () {
		SuperStart ();
		nombre = "Rabiar";
		prefab_efecto = Resources.Load("PrefabsCargados/Habilidades/prefab_rabiar") as GameObject;

		costo_resistencia = 10;
		tiempo_duracion_base = 10;
		tiempo_duracion_contador = tiempo_duracion_base;
		tiempo_reutilizacion_base = 60;
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
					jugadorEstadisticas.Fuerza_magica_destructora_actual = valor_inicial_FMD;
					jugadorEstadisticas.Fuerza_fisica_actual = valor_inicial_FF;

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

		//print (esta_activada + " " + jugadorEstadisticas.Resistencia_actual);
		if (!esta_activada && !esta_reutilizacion && jugadorEstadisticas.Resistencia_actual >= costo_resistencia) {


			jugadorEstadisticas.Resistencia_actual -= costo_resistencia;

			valor_inicial_FF = jugadorEstadisticas.Fuerza_fisica_actual;
			valor_inicial_FMD = jugadorEstadisticas.Fuerza_magica_destructora_actual;
			jugadorEstadisticas.Fuerza_magica_destructora_actual *= 2;
			jugadorEstadisticas.Fuerza_fisica_actual *= 2;

			esta_activada = true;
			Instantiate (prefab_efecto, new Vector3(this.transform.position.x,this.transform.position.y, -0.2f), this.transform.rotation);
		}


	}

}
