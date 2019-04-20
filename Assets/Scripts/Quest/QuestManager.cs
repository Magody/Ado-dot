using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {


	public static string ultimo_enemigo_asesinado;
	public static string ultimo_objeto_recolectado;
	public QuestObject[] misiones;
	public bool[] mision_cumplida;
	public int mision_actual;

	void Start () {
		mision_cumplida = new bool[misiones.Length];
	}
	

	void Update () {
		
			
	}

	public void mostrarTextoMision(){
		if (mision_actual < misiones.Length) {
			if (!mision_cumplida [mision_actual])
				DialogManager.IniciarDialogo (misiones [mision_actual]);
			else
				DialogManager.IniciarDialogo (new string[]{"Ya realizaste esa misión"});
		} else {
			DialogManager.IniciarDialogo (new string[]{"Me has ayudado en todo", "!Gracias!"});
		}
	}


}
