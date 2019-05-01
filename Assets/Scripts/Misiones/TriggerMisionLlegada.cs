using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMisionLlegada : MonoBehaviour {
	
	private Mision mision;

	void Start(){
		mision = GetComponentInParent<Mision> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == ControladorGlobal.jugador.name) {
			mision.finalizarMision ();
		}
	}
}
