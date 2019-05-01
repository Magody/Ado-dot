using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorMisiones : MonoBehaviour {
	/*Administra el conjunto de misiones de un NPC especifico*/

	public static string ultimo_enemigo_asesinado;
	public static string ultimo_objeto_recolectado;
	public Mision[] misiones;
	public bool[] mision_cumplida;
	public int mision_actual;

	void Start () {
		mision_cumplida = new bool[misiones.Length];
	}

	public void mostrarTextoMision(){
		if (mision_actual < misiones.Length) {
			if (!mision_cumplida [mision_actual])
				ManejadorDialogos.IniciarDialogo (misiones [mision_actual]);
			else
				ManejadorDialogos.IniciarDialogo (Mensajes.MSG_MISION_YA_REALIZADA);
		} else {
			ManejadorDialogos.IniciarDialogo (Mensajes.MSG_NPC_SIN_MISIONES);
		}
	}


}
