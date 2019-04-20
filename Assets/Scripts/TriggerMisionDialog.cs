using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMisionDialog : MonoBehaviour {
	//interactaudor es el E

	GameObject obj_col;
	public QuestManager questManager;

	void Start () {
		
	}

	void Update () {


		if (obj_col != null) {
			
			if(Input.GetKeyDown(KeyCode.E) && !DialogManager.dialogo_activo){
				if(obj_col.tag == "Player"){
					questManager.mostrarTextoMision();
				}
			}
		}

	}


	void OnTriggerEnter2D(Collider2D col){

		obj_col = col.gameObject;

	}

	void OnTriggerExit2D(Collider2D col){

		obj_col = null;

	}

}
