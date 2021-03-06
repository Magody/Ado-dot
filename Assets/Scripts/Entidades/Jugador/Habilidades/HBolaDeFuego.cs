﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBolaDeFuego : Habilidad {



	// Use this for initialization
	void Start () {
		SuperStart ();
		nombre = "BolaDeFuego";
		prefab_efecto = Resources.Load("PrefabsCargados/Habilidades/prefab_bola_fuego") as GameObject;

		costo_mana = 20;
		tiempo_duracion_base = 0;
		tiempo_duracion_contador = tiempo_duracion_base;
		tiempo_reutilizacion_base = 5;
		tiempo_reutilizacion_contador = tiempo_reutilizacion_base;
	}
	
	// Update is called once per frame
	void Update () {

		if (!esta_reutilizacion) {
			if (esta_activada) {

				var clone = (GameObject)Instantiate (prefab_efecto, new Vector3(this.transform.position.x+jugador.AxisUltimo.x,this.transform.position.y+jugador.AxisUltimo.y, this.transform.position.z)
					, this.transform.rotation);
				clone.GetComponent<ControladorBolaDeFuego> ().Direccion = jugador.AxisUltimo;
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
			ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_BOLA_DE_FUEGO);
			jugador.JugadorEstadisticas.Mana_actual -= costo_mana;
			esta_activada = true;
		}


	}





}
