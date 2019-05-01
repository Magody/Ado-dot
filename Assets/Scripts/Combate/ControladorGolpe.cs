using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGolpe : MonoBehaviour {

	/*crea un bloque activable en frente del jugador haciendo de golpe*/

	private float danio;
	private JugadorEstadisticas jugadorEstadisticas;


	void Start () {
		jugadorEstadisticas = ControladorGlobal.jugador.JugadorEstadisticas;
	}


	void OnTriggerEnter2D(Collider2D collider){

		if (collider.gameObject.tag == ControladorGlobal.STRING_TAG_ENEMIGO) {
			danio = jugadorEstadisticas.Fuerza_fisica_actual;

			bool es_critico = ManejadorCombate.esCritico(jugadorEstadisticas.Critico);
			if (es_critico) {
				danio *= 2;
				ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_GOLPES[2]);
			} else
				ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_GOLPES[Random.Range(0,2)]);
			
			ManejadorCombate.danioFlotanteAlEnemigoPorTrigger(this.transform, jugadorEstadisticas, collider, danio, es_critico, ControladorGlobal.jugador.ManejadorHabilidadesPasivas.Tiene_vampirismo);
			
			//puede entrenar una destreza con sus manos
			if (ControladorGlobal.jugador.ManejadorDestrezas.Esta_entrenando && ControladorGlobal.jugador.ManejadorDestrezas.Tema_entrenamiento == "FF") {

				int aleatorio = Random.Range (1, 101);

				if(aleatorio == 2) //2% prob de entrenar con puño
					ControladorGlobal.jugador.ManejadorDestrezas.entrenar ();
			}

		}
	}



}
