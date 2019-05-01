using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision : MonoBehaviour {
	/*Este es un template para tres misiones básicas, cada mision deberia tener su propio script
	este script no es definitivo*/

	private const int VIAJE=1, MATAR=2,RECOLECTAR=3;

	public int tipo,numero_mision, enemigos, experiencia;
	public string enemigo_nombre_clave,objeto_recolectado_nombre;
	public string[] texto_mision;
	protected ManejadorMisiones manejadorMisiones;


	void Start(){
		manejadorMisiones = GetComponentInParent<ManejadorMisiones> ();
	}

	void Update(){

		switch (tipo) {
		case VIAJE:
			break;
		case MATAR:

			if (ManejadorMisiones.ultimo_enemigo_asesinado != null) {

				if (ManejadorMisiones.ultimo_enemigo_asesinado.Contains (enemigo_nombre_clave)) {
					ManejadorMisiones.ultimo_enemigo_asesinado = null;
					enemigos--;
				}

			}

			if (enemigos == 0) {
				finalizarMision ();
			}

			break;

		case RECOLECTAR:

			if (ManejadorMisiones.ultimo_objeto_recolectado == objeto_recolectado_nombre) {
				finalizarMision ();
			}
			break;
		}



	}



	public void empezarMision(){
		gameObject.SetActive (true);

	}

	public void finalizarMision(){
		ManejadorDialogos.IniciarDialogo (Mensajes.MSG_MISION_COMPLETADA);
		ManejadorDialogos.IniciarDialogo (new string[]{""+numero_mision});

		gameObject.SetActive (false);
		manejadorMisiones.mision_cumplida [numero_mision] = true;
		manejadorMisiones.mision_actual++;
		ControladorGlobal.jugador.JugadorEstadisticas.Experiencia_actual = ControladorGlobal.jugador.JugadorEstadisticas.Experiencia_actual + experiencia;
	
	}

}
