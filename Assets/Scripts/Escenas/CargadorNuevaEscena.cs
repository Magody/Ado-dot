using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargadorNuevaEscena : MonoBehaviour {
	/*Se ubica en triggers y al ser topados nos llevan a otro mapa con una posicion establecida*/

	public Vector3 posicionSalida;
	public Vector2 direccionSalida;
	public string escena_a_cargar; //se debe cargar antes

	private ControladorCamara controladorCamara;


	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.gameObject.name == ControladorGlobal.jugador.name) 
		{
			
			ControladorGlobal.jugador.Puede_moverse = false;

			ControladorGlobal.jugador.transform.position = posicionSalida;
			ControladorGlobal.jugador.Rb.velocity = new Vector2 (0, 0);
			ControladorGlobal.jugador.AxisUltimo = direccionSalida;




			controladorCamara = FindObjectOfType<ControladorCamara> ();
			controladorCamara.transform.position = new Vector3 (posicionSalida.x,posicionSalida.y, controladorCamara.transform.position.z);

			SceneManager.LoadScene (escena_a_cargar);
		}

	}

}
