using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMisionDialogo : MonoBehaviour {
	/*interactuador con E para iniciar una mision*/

	GameObject objeto_chocado;
	public ManejadorMisiones manejadorMisiones;


	void Update () {


		if (objeto_chocado != null) {
			
			if(Input.GetKeyDown(KeyCode.E) && !ManejadorDialogos.dialogo_activo){
				if(objeto_chocado.name == ControladorGlobal.jugador.name){
					manejadorMisiones.mostrarTextoMision();
				}
			}
		}

	}


	void OnTriggerEnter2D(Collider2D collider){

		objeto_chocado = collider.gameObject;

	}

	void OnTriggerExit2D(Collider2D collider){

		objeto_chocado = null;

	}

}
