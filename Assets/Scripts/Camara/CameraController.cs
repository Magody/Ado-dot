using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject follow_target;
	private Vector3 target_position;
	public float move_speed;


	private static bool camera_exist;
	GameObject boundCamera;
	float clampedX, clampedY;
	float ancho_vision_mitad, alto_vision_mitad;
	BoxCollider2D bounds_box;
	Vector3 min_bound, max_bound;

	private Camera cam;

	// Use this for initialization
	void Start () {

		if (!CameraController.camera_exist) {
			CameraController.camera_exist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		boundCamera = GameObject.FindGameObjectWithTag ("bounds");
		bounds_box = boundCamera.GetComponent<BoxCollider2D> ();
		cam = GetComponent<Camera> ();
		min_bound = bounds_box.bounds.min;
		max_bound = bounds_box.bounds.max;

		alto_vision_mitad = cam.orthographicSize;
		ancho_vision_mitad = alto_vision_mitad * Screen.width/Screen.height;

	}
	
	// Update is called once per frame
	void Update () {
		target_position = new Vector3 (follow_target.transform.position.x,follow_target.transform.position.y,transform.position.z);
		transform.position = Vector3.Lerp (transform.position, target_position, move_speed*Time.deltaTime);


		if(boundCamera == null){
			try {
				setBounds ();
			} catch (System.Exception ex) {
				print ("ES NECESARIO AGREGAR UN BOUNDS con su etiqueta y boxcollider2D en cada mapa " + ex);
			}
		}


		clampedX = Mathf.Clamp (cam.transform.position.x, min_bound.x + ancho_vision_mitad, max_bound.x -  ancho_vision_mitad);
		clampedY = Mathf.Clamp (cam.transform.position.y, min_bound.y + alto_vision_mitad, max_bound.y -  alto_vision_mitad);
		transform.position = new Vector3 (clampedX, clampedY, transform.position.z);

	}


	public void setBounds(){
		boundCamera = GameObject.FindGameObjectWithTag ("bounds");
		bounds_box = boundCamera.GetComponent<BoxCollider2D> ();
		min_bound = bounds_box.bounds.min;
		max_bound = bounds_box.bounds.max;
	}

}
