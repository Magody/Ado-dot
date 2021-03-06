﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCuracion : Habilidad {

	void Start () {
		SuperStart ();
		nombre = "Curación";
		prefab_efecto = Resources.Load("PrefabsCargados/Habilidades/prefab_sanacion") as GameObject;

		costo_mana = 25;
		tiempo_duracion_base = 0;
		tiempo_duracion_contador = tiempo_duracion_base;
		tiempo_reutilizacion_base = 7;
		tiempo_reutilizacion_contador = tiempo_reutilizacion_base;


	}

	// Update is called once per frame
	void Update () {

		if (!esta_reutilizacion) {
			if (esta_activada) {


				ManejadorCombate.sanacionFlotanteAlJugador (this.transform, jugadorEstadisticas.Vida_base [jugador.JugadorEstadisticas.Nivel_actual] * 0.1f, jugadorEstadisticas,2f); //10%

				Instantiate (prefab_efecto, new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z-1f), this.transform.rotation);
				esta_activada = false;
				esta_reutilizacion = true;
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

		if (!esta_activada && !esta_reutilizacion && jugador.JugadorEstadisticas.Mana_actual >= costo_mana) {
			ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_CURACION);
			jugador.JugadorEstadisticas.Mana_actual -= costo_mana;
			esta_activada = true;
		}


	}

}
