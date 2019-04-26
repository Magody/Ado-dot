using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorPrefab : MonoBehaviour {

	public GameObject objeto;
	public int maximo;
	private int contador_instanciacion;
	public float tiempo_instanciacion;
	private float tiempo_instanciacion_contador;


	// Use this for initialization
	void Start () {
		tiempo_instanciacion_contador = tiempo_instanciacion;
	}
	
	// Update is called once per frame
	void Update () {

		if (ControladorGlobal.flujo_normal_tiempo) {
			if (contador_instanciacion < maximo) {
				tiempo_instanciacion_contador -= Time.deltaTime;

				if (tiempo_instanciacion_contador < 0) {

					Instantiate (objeto, this.transform.position, this.transform.rotation);
					contador_instanciacion++;
					tiempo_instanciacion_contador = tiempo_instanciacion;
				}
			} else {
			
				Destroy (this.gameObject);
			}
		}

	}
}
