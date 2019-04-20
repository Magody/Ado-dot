using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public Slider barra_vida;
	public Slider barra_exp;
	public Text text_barra_vida;
	public Text text_barra_exp;
	public Text text_nivel;
	public Text text_crítico;

	private JugadorControlador jugadorControlador;

	private static bool UI_exist;
	// Use this for initialization
	void Start () {
		
		if (!UIManager.UI_exist) {
			jugadorControlador = FindObjectOfType<JugadorControlador> ();
			UIManager.UI_exist = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {
			Destroy (this.gameObject);
		}



	}
	
	// Update is called once per frame
	void Update () {

		JugadorEstadisticas estadisticas = jugadorControlador.JugadorEstadisticas;
		int nivel = jugadorControlador.JugadorEstadisticas.Nivel_actual;

		barra_vida.maxValue = estadisticas.Vida_base[nivel];

		if (nivel < estadisticas.Experiencia_para_subir.Length-1) {
			barra_exp.maxValue = estadisticas.Experiencia_para_subir [nivel];
			text_barra_exp.text = estadisticas.Experiencia_actual + "/" + estadisticas.Experiencia_para_subir [nivel];

		} else {
			barra_exp.maxValue = estadisticas.Experiencia_actual;
			text_barra_exp.text = estadisticas.Experiencia_actual + "/" + estadisticas.Experiencia_actual;

		}

		barra_vida.value = estadisticas.Vida_actual;
		barra_exp.value = estadisticas.Experiencia_actual;
		text_barra_vida.text = estadisticas.Vida_actual + "/" + estadisticas.Vida_base[nivel];

		text_nivel.text = "Nivel: " + nivel;


		text_crítico.text = "CR: " + estadisticas.Critico + "\nFF: " +  estadisticas.Fuerza_fisica_actual;
	}
}
