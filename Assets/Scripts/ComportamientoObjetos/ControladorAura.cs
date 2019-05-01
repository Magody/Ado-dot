using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAura : MonoBehaviour {

	/*Hace que el aura persiga al jugador dando el efecto que sale del mismo. 
		Un Aura ocurre cuando sale colores del personaje y aumenta sus estadísticas o las reduce*/
	
	void Update () {
		this.transform.position = new Vector3(ControladorGlobal.jugador.transform.position.x, ControladorGlobal.jugador.transform.position.y, -0.2f);
	}
}
