using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_talento : MonoBehaviour {

	public string rama;
	public int id;
	JugadorControlador jugadorControlador;

	bool debe_desaparecer;
	float tiempo_desaparicion ;
	float tiempo_desaparicion_contador;
	SpriteRenderer spriteRenderer;
	void Start(){
		
		jugadorControlador = FindObjectOfType<JugadorControlador> ();
		tiempo_desaparicion = 0.5f;
		tiempo_desaparicion_contador = tiempo_desaparicion;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update(){

		if (debe_desaparecer) {
			animacionDesaparicion ();
		}
	}


	void animacionDesaparicion(){

		float unidad_de_tiempo = Time.deltaTime;
		tiempo_desaparicion_contador -= unidad_de_tiempo;
		spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,spriteRenderer.color.a-unidad_de_tiempo);

		if (tiempo_desaparicion_contador < 0) {
			Destroy (this);
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.name == jugadorControlador.name) {

			if (jugadorControlador.JugadorEstadisticas.Talentos.Puntos_talento > 0) {
				
				jugadorControlador.JugadorEstadisticas.Talentos.renovarTalentos (id, rama);
				print ("Talento: " + id + " de la rama " + rama + " activado.");
				debe_desaparecer = true;
				this.GetComponent<BoxCollider2D> ().enabled = false;
				jugadorControlador.JugadorEstadisticas.Talentos.Puntos_talento -= 1;
		
			} else {
				print ("No hay suficientes talentos");
			}
		}
	}

}
