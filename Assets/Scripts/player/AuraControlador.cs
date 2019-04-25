using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraControlador : MonoBehaviour {

	JugadorControlador jugadorControlador;


	// Use this for initialization
	void Start () {
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
	}
	
	// Update is called once per frame
	void Update () {


		this.transform.position = new Vector3(jugadorControlador.transform.position.x, jugadorControlador.transform.position.y, -0.2f);
	}
}
