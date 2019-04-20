using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {


	const int VIAJE=1, MATAR=2,RECOLECTAR=3;

	public int tipo,numero_mision, enemigos, experiencia;
	public string enemigo_nombre_clave,objetoRecolectado_nombre_clave;
	public string[] texto_mision;
	protected JugadorControlador jugadorControlador;
	protected QuestManager questManager;


	void Start(){
		questManager = GetComponentInParent<QuestManager> ();
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
	}

	void Update(){

		switch (tipo) {
		case VIAJE:
			break;
		case MATAR:

			if (QuestManager.ultimo_enemigo_asesinado != null) {

				if (QuestManager.ultimo_enemigo_asesinado.Contains (enemigo_nombre_clave)) {
					QuestManager.ultimo_enemigo_asesinado = null;
					enemigos--;
				}

			}

			if (enemigos == 0) {
				finalizarMision ();
			}

			break;

		case RECOLECTAR:

			if (QuestManager.ultimo_objeto_recolectado == objetoRecolectado_nombre_clave) {
				finalizarMision ();
			}
			break;
		}



	}



	public void empezarMision(){
		gameObject.SetActive (true);

	}

	public void finalizarMision(){
		print ("Has terminado la mision " + numero_mision);
		gameObject.SetActive (false);
		questManager.mision_cumplida [numero_mision] = true;
		questManager.mision_actual++;
		jugadorControlador.JugadorEstadisticas.Experiencia_actual = jugadorControlador.JugadorEstadisticas.Experiencia_actual + experiencia;
	
	}

}
