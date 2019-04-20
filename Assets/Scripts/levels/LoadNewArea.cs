using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

	private JugadorControlador player_controller;
	private CameraController camera_controller;
	public string level2load;
	public Vector3 posicion_salida;
	public Vector2 direccion_salida;
	string jugador;

	// Use this for initialization
	void Start () {
		jugador = GameObject.FindGameObjectWithTag ("Player").name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.name == jugador) 
		{
			

			player_controller = FindObjectOfType<JugadorControlador> ();
			player_controller.Can_move = false;

			player_controller.transform.position = posicion_salida;
			player_controller.Rb.velocity = new Vector2 (0, 0);
			player_controller.Last_move = direccion_salida;




			camera_controller = FindObjectOfType<CameraController> ();
			camera_controller.transform.position = new Vector3 (posicion_salida.x,posicion_salida.y, camera_controller.transform.position.z);

			SceneManager.LoadScene (level2load);
		}

	}

}
