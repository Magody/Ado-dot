using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTalento : MonoBehaviour {

	public string rama;
	public int id;
	public TriggerTalento[] triggers_hijos;
	JugadorControlador jugadorControlador;

	bool debe_desaparecer;
	bool se_puede_recoger;

	float tiempo_desaparicion ;
	float tiempo_desaparicion_contador;
	SpriteRenderer spriteRenderer;

	Talentos talentos;

	bool se_ha_activado_una_vez;
	float tiempo_loading = 3;

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
		if (tiempo_loading >= 0)
			tiempo_loading -= Time.deltaTime;
		else if (tiempo_loading < 0 && !se_ha_activado_una_vez) {
			se_ha_activado_una_vez = true;

			talentos = FindObjectOfType<JugadorControlador> ().JugadorEstadisticas.Talentos;
			se_puede_recoger = talentos.esPosibleRecoger (rama, id);
			if (!se_puede_recoger) {
				spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
			}

		} 
			


	}

	private void activarTalentosHijos(){
		se_puede_recoger = true;
		spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

	}


	void animacionDesaparicion(){

		float unidad_de_tiempo = Time.deltaTime;
		tiempo_desaparicion_contador -= unidad_de_tiempo;
		spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,spriteRenderer.color.a-unidad_de_tiempo);

		if (tiempo_desaparicion_contador < 0) {
			spriteRenderer.color = Color.black;
			Destroy (this);
		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.name == jugadorControlador.name) {

			if (se_puede_recoger) {
				if (jugadorControlador.JugadorEstadisticas.Talentos.Puntos_talento > 0) {
				
					jugadorControlador.JugadorEstadisticas.Talentos.renovarTalentos (id, rama);
					print ("Talento: " + id + " de la rama " + rama + " activado.");
					debe_desaparecer = true;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					jugadorControlador.JugadorEstadisticas.Talentos.Puntos_talento -= 1;

					if(triggers_hijos != null)
						foreach (TriggerTalento trigger in triggers_hijos) {
							trigger.activarTalentosHijos ();
						}

				} else {
					print ("No hay suficientes talentos");
				}
			} else {
				print ("Debes desbloquear un talento superior antes");
			}
		}
	}

}
