using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGlobal : MonoBehaviour {

	public static SpriteRenderer fondo_flujo_anormal_tiempo;
	public static bool flujo_normal_tiempo = true;

	void Start(){
		ControladorGlobal.fondo_flujo_anormal_tiempo = GameObject.Find ("flujo_anormal_tiempo").GetComponent<SpriteRenderer>();
	}

}
