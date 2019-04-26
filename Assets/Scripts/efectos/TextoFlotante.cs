using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextoFlotante : MonoBehaviour {

	public float velocidad_movimiento;
	public string texto;
	public Text text_numero;
	private int tamanio;
	private JugadorControlador jugadorControlador;
	// Use this for initialization
	void Start () {
		tamanio = text_numero.fontSize;
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
	}

	// Update is called once per frame
	void Update () {
		
		text_numero.text = texto;


		if (velocidad_movimiento < 2) {
			transform.position = 
				new Vector3 (jugadorControlador.transform.position.x, 
				transform.position.y + velocidad_movimiento * Time.deltaTime,
				transform.position.z);
		} else {
			transform.position = 
				new Vector3 (transform.position.x, 
					transform.position.y + velocidad_movimiento * Time.deltaTime,
					transform.position.z);
		}
		
	}

	public int Tamanio {
		get {
			return this.tamanio;
		}
		set {
			tamanio = value;
		}
	}
}
