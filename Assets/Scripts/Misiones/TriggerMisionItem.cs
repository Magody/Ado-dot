using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMisionItem : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.name == ControladorGlobal.jugador.name) {
			ManejadorMisiones.ultimo_objeto_recolectado = name;
			Destroy (gameObject);
		}
	}

}
