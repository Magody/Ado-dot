using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRecolectarItem : MonoBehaviour {


	string objetivo;

	void Start(){
		objetivo = GameObject.FindGameObjectWithTag ("Player").name;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == objetivo) {
			QuestManager.ultimo_objeto_recolectado = name;
			Destroy (gameObject);
		}
	}

}
