using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManejadorUI : MonoBehaviour {
	/*Se ocupa de la interfaz de usuario*/

	private static bool UI_exist;

	//public float x=10, y=10, ancho=10, alto=10;

	public Slider barraVida;
	public Slider barraExp;
	public Slider barraEntrenamiento;
	public Text textBarraVida;
	public Text textBarraExp;
	public Text textNivel;
	private Jugador jugadorControlador;
	private JugadorEstadisticas estadisticas;
	void Start () {
		
		if (!ManejadorUI.UI_exist) {
			jugadorControlador = FindObjectOfType<Jugador> ();
			ManejadorUI.UI_exist = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {
			Destroy (this.gameObject);
		}

		barraEntrenamiento.maxValue = 1f;

	}
	
	// Update is called once per frame
	void Update () {

		estadisticas = jugadorControlador.JugadorEstadisticas;
		int nivel = jugadorControlador.JugadorEstadisticas.Nivel_actual;

		barraVida.maxValue = estadisticas.Vida_base[nivel];

		if (nivel < estadisticas.Experiencia_para_subir.Length-1) {
			barraExp.maxValue = estadisticas.Experiencia_para_subir [nivel];
			textBarraExp.text = estadisticas.Experiencia_actual + "/" + estadisticas.Experiencia_para_subir [nivel];

		} else {
			barraExp.maxValue = estadisticas.Experiencia_actual;
			textBarraExp.text = estadisticas.Experiencia_actual + "/" + estadisticas.Experiencia_actual;

		}

		barraVida.value = estadisticas.Vida_actual;
		barraExp.value = estadisticas.Experiencia_actual;

		if (jugadorControlador.ManejadorDestrezas.Esta_entrenando && jugadorControlador.ManejadorDestrezas.Meta_entrenamiento > 0) {
			barraEntrenamiento.value = (float)jugadorControlador.ManejadorDestrezas.Meta_entrenamiento_contador / (float)jugadorControlador.ManejadorDestrezas.Meta_entrenamiento;

			//print (jugadorControlador.Destrezas.Meta_entrenamiento_contador / jugadorControlador.Destrezas.Meta_entrenamiento);
		}
		else {
			barraEntrenamiento.value = 0;
		}
		
		textBarraVida.text = estadisticas.Vida_actual + "/" + estadisticas.Vida_base[nivel];

		textNivel.text = "Nivel: " + nivel;



	}

	void OnGUI(){

		//FALTA HACER RESPONSIVE
		GUI.Box (new Rect(33.68f,457.5f,130.25f,281.87f),"ESTADISTICAS\n" + estadisticas.leerResumenEstadisticas ());

	}

}
