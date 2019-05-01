using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTalento : MonoBehaviour {

	public string rama;
	public int id;
	public TriggerTalento[] triggersTalentos;

	private bool debe_desaparecer;
	private bool se_puede_recoger;
	private float tiempo_desaparicion;
	private float tiempo_desaparicion_contador;
	private SpriteRenderer spriteRenderer;
	private Talentos talentos;
	private bool se_ha_activado_una_vez;
	private float tiempo_loading = 3;

	void Start(){
		

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

			talentos = ControladorGlobal.jugador.JugadorEstadisticas.Talentos;
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

		if (col.name == ControladorGlobal.jugador.name) {

			if (se_puede_recoger) {
				if (ControladorGlobal.jugador.JugadorEstadisticas.Talentos.Puntos_talento > 0) {
				
					ControladorGlobal.jugador.JugadorEstadisticas.Talentos.renovarTalentos (id, rama);

					ManejadorDialogos.IniciarDialogo (new string[]{"Talento: " + id + " de la rama " + rama + " activado.\n",
						ControladorGlobal.jugador.JugadorEstadisticas.Talentos.leerInformacionTalento(rama,id)});

					debe_desaparecer = true;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					ControladorGlobal.jugador.JugadorEstadisticas.Talentos.Puntos_talento -= 1;

					if(triggersTalentos != null)
						foreach (TriggerTalento trigger in triggersTalentos) {
							trigger.activarTalentosHijos ();
						}

				} else {
					ManejadorDialogos.IniciarDialogo (new string[]{"No hay suficientes talentos"});
				}
			} else {
				ManejadorDialogos.IniciarDialogo (new string[]{"Debes desbloquear un talento superior antes"});
			}
		}
	}

}
