using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDetenerTiempo : Habilidad {



	void Start () {
		SuperStart ();
		nombre = "DetenerTiempo";

		costo_mana = 0.8f; //80% del total

		tiempo_duracion_base = 5;
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
					ControladorGlobal.flujo_normal_tiempo = true;
					ControladorGlobal.fondo_flujo_anormal_tiempo.enabled = false;
					ControladorGlobal.manejadorMusica.cambiarMusica (ManejadorMusica.musicaAnterior);

					print ("Tiempo restablecido");
					//Destroy(GameObject.Find(prefab_efecto.name+"(Clone)"));
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


		if (!esta_activada && !esta_reutilizacion && jugadorEstadisticas.Mana_actual >= costo_mana*jugadorEstadisticas.Mana_actual) {

			jugadorEstadisticas.Mana_actual -= costo_mana*jugadorEstadisticas.Mana_actual;
			ControladorGlobal.flujo_normal_tiempo = false;
			ControladorGlobal.fondo_flujo_anormal_tiempo.enabled = true;
			esta_activada = true;
			ControladorGlobal.manejadorMusica.cambiarMusica (ManejadorMusica.MUSICA_TIEMPO_DETENIDO);
			print ("Tiempo detenido");
			//Instantiate (prefab_efecto, new Vector3(this.transform.position.x,this.transform.position.y, -0.2f), this.transform.rotation);
		}


	}





}