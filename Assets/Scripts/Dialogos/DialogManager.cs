using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogManager : MonoBehaviour {


	public static GameObject dbox; //caja del diálogo
	public static Text text_mensaje;
	private static int linea_actual;
	private static string[] lineas;
	public static bool dialogo_activo;


	static QuestObject questObject;
	static bool es_dialogo_mision;

	void Start(){

		dbox = GameObject.Find ("DialogueBox");
		dbox.SetActive (true);
		text_mensaje = GameObject.Find ("GeneralText").GetComponent<Text>();
		dialogo_activo = false;
		dbox.SetActive (false);
	}


	public static void IniciarDialogo (string[] li) {
		//linea actual


		if (dialogo_activo) {

			string[] copia = lineas;
			lineas = new string[copia.Length-(linea_actual-1)+li.Length];


			int indice_global = 0;
			for (int i = linea_actual-1; i < copia.Length; i++,indice_global++) {
				lineas [indice_global] = copia [i];
			}

			for (int j = 0; j < li.Length; indice_global++, j++) {
				lineas [indice_global] = li [j];
			}


		} else {
			lineas = li;
		}
		linea_actual = 0;
		es_dialogo_mision = false;
		mostrarMensaje (lineas[linea_actual++]);


	}

	public static void IniciarDialogo (QuestObject qObject) {
		//linea actual
		lineas = qObject.texto_mision;
		linea_actual = 0;
		es_dialogo_mision = true;
		questObject = qObject;
		mostrarMensaje (lineas[linea_actual++]);
	}
	
	// Update is called once per frame
	void Update () {

		if (es_dialogo_mision) {
			if (dialogo_activo) {

				if (Input.GetKeyDown (KeyCode.Space)) {
					if (linea_actual < lineas.Length) {
						mostrarMensaje (lineas [linea_actual++]);
					} else {
						mostrarMensaje ("Aceptar: A, Rechazar: R");
					}
				} else if (linea_actual == lineas.Length) {

					if (Input.GetKeyDown (KeyCode.A)) {
						questObject.empezarMision ();
						print ("mision aceptada");
						dialogo_activo = false;
						dbox.SetActive (false);
					} else if (Input.GetKeyDown (KeyCode.R)) {
						print ("mision rechazada");
						dialogo_activo = false;
						dbox.SetActive (false);
					}




				}
			}
		} else {
			if (dialogo_activo && Input.GetKeyDown (KeyCode.Space)) {
				if (linea_actual < lineas.Length) {
					mostrarMensaje (lineas [linea_actual++]);
				} else {
					dialogo_activo = false;
					dbox.SetActive (false);
				}
			} 
		}

		
	}


	private static void mostrarMensaje(string mensaje){
		dialogo_activo = true;
		dbox.SetActive (true);
		text_mensaje.text = mensaje;
	}

}
