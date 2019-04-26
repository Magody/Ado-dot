using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {



	public float velocidad_movimiento;
	private Rigidbody2D rb;
	private bool esta_caminando;
	private int direccion;

	//timers
	private float tiempo_caminata = 1;
	private float tiempo_caminata_contador;
	private float tiempo_espera = 2;
	private float tiempo_espera_contador;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		tiempo_caminata_contador = tiempo_caminata;
		tiempo_espera_contador = tiempo_espera;
		direccion = Random.Range (0, 3);

	}
	
	// Update is called once per frame
	void Update () {

		if (ControladorGlobal.flujo_normal_tiempo) {
			if (!esta_caminando) {
				rb.velocity = Vector2.zero;

				tiempo_espera_contador -= Time.deltaTime;
				if (tiempo_espera_contador < 0) {
					esta_caminando = true;
					tiempo_espera_contador = tiempo_espera;
				}
			} else {
				tiempo_caminata_contador -= Time.deltaTime;

				switch (direccion) {

				case 0:
					rb.velocity = new Vector2 (0, velocidad_movimiento);
					break;
				case 1:
					rb.velocity = new Vector2 (velocidad_movimiento, 0);
					break;
				case 2:
					rb.velocity = new Vector2 (0, -velocidad_movimiento);
					break;
				case 3:
					rb.velocity = new Vector2 (-velocidad_movimiento, 0);
					break;
				}


				if (tiempo_caminata_contador < 0) {
					esta_caminando = false;
					direccion = Random.Range (0, 3);
					tiempo_caminata_contador = tiempo_caminata;
				}
			}
		} else {
			detenerTiempoPropio ();
			esta_caminando = true;
		}
	}

	private void detenerTiempoPropio(){
		rb.velocity = Vector2.zero;
	}


}
