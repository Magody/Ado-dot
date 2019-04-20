using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLlegada : MonoBehaviour {


	string objetivo;
	QuestObject questObject;

	void Start(){
		questObject = GetComponentInParent<QuestObject> ();
		objetivo = GameObject.FindGameObjectWithTag ("Player").name;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == objetivo) {
			questObject.finalizarMision ();
		}
	}
}
