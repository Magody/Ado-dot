using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour {
	/*Provoca que la camara siga automáticamente a objetivoASeguir(jugador) con un velocidad igual a velocidad_movimiento (5)*/

	private static bool existe_camara;

	public GameObject objetivoASeguir;
	public float velocidad_movimiento;

	private GameObject boundsCamara; //es el confinamiento de su vision, es un objeto prefab
	private Vector3 objetivoPosicion;
	private float clamped_x, clamped_y; //es el valor al que se le va a restringir para no exeder la visión del mapa
	private float vision_ancho_mitad, vision_alto_mitad;
	private BoxCollider2D boundsBoxCollider2D;
	private Vector3 bounds_min, bounds_max;
	private Camera camara;


	void Start () {
		if (!ControladorCamara.existe_camara) {
			ControladorCamara.existe_camara = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		boundsCamara = GameObject.FindGameObjectWithTag ("bounds");  // requiere de un prefab invisible con el tamaño del mapa
		boundsBoxCollider2D = boundsCamara.GetComponent<BoxCollider2D> ();
		camara = GetComponent<Camera> ();
		bounds_min = boundsBoxCollider2D.bounds.min;
		bounds_max = boundsBoxCollider2D.bounds.max;

		vision_alto_mitad = camara.orthographicSize; //los valores retornados corresponden a la mitad real
		vision_ancho_mitad = vision_alto_mitad * Screen.width/Screen.height; //regla de tres para encontrar el ancho
	}


	void Update () {
		objetivoPosicion = new Vector3 (objetivoASeguir.transform.position.x, objetivoASeguir.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, objetivoPosicion, velocidad_movimiento*Time.deltaTime);

		// este condicional es para cuando se cambia de nivel y los bounds principales desaparecen
		if(boundsCamara == null){
			try {
				establecerBounds ();
			} catch (System.Exception ex) {
				Debug.Log ("ES NECESARIO AGREGAR UN BOUNDS con su etiqueta 'bounds' y boxcollider2D en cada mapa " + ex);
			}
		}

		clamped_x = Mathf.Clamp (camara.transform.position.x, bounds_min.x + vision_ancho_mitad, bounds_max.x -  vision_ancho_mitad);
		clamped_y = Mathf.Clamp (camara.transform.position.y, bounds_min.y + vision_alto_mitad, bounds_max.y -  vision_alto_mitad);
		transform.position = new Vector3 (clamped_x, clamped_y, transform.position.z);  // restringe su posición a los bounds
	}


	void establecerBounds(){
		boundsCamara = GameObject.FindGameObjectWithTag ("bounds");
		boundsBoxCollider2D = boundsCamara.GetComponent<BoxCollider2D> ();
		bounds_min = boundsBoxCollider2D.bounds.min;
		bounds_max = boundsBoxCollider2D.bounds.max;
	}

	public GameObject ObjetivoASeguir {		get {			return this.objetivoASeguir;		}		set {			objetivoASeguir = value;		}	}

	public float Velocidad_movimiento {		get {			return this.velocidad_movimiento;		}		set {			velocidad_movimiento = value;		}	}
}
