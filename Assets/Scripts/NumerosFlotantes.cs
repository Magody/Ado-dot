using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumerosFlotantes : MonoBehaviour {

	public float velocidad_movimiento;
	public float numero;
	public Text text_numero;
	private int tamanio;

	// Use this for initialization
	void Start () {
		tamanio = text_numero.fontSize;
	}

	// Update is called once per frame
	void Update () {
		
		text_numero.text = "" + numero;
		transform.position = 
			new Vector3 (transform.position.x, 
				transform.position.y + velocidad_movimiento * Time.deltaTime,
				transform.position.z);
		
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
