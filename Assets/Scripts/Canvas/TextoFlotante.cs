using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextoFlotante : MonoBehaviour {
	/*Clase encargada de utilizar un elemento canvas con un Text para mostrar un mensaje fuera del GUI
	se le puede modificar el texto, tamaño, velocidad y color del text*/

	public Text text;

	private int tamanio;
	private float velocidad_movimiento;
	private string texto;

	void Start () {
		tamanio = text.fontSize;
		velocidad_movimiento = 2;
	}

	void Update () {
		
		text.text = texto;

		if (velocidad_movimiento < 2) {
			transform.position = 
				new Vector3 (ControladorGlobal.jugador.transform.position.x, 
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

	public float Velocidad_movimiento {
		get {
			return this.velocidad_movimiento;
		}
		set {
			velocidad_movimiento = value;
		}
	}

	public string Texto {
		get {
			return this.texto;
		}
		set {
			texto = value;
		}
	}

	public Text Text {
		get {
			return this.text;
		}
		set {
			text = value;
		}
	}
}
