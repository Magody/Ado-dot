using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesPasivas {


	private bool tiene_vampirismo;
	JugadorEstadisticas jugadorEstadisticas;
	// Use this for initialization
	public HabilidadesPasivas(JugadorEstadisticas jugadorEstadisticas) {
		this.jugadorEstadisticas = jugadorEstadisticas;
		
	}

	public void habilitarPasivaMago(){
		for (int i = 0; i < jugadorEstadisticas.Mana_base.Length; i++) {
			jugadorEstadisticas.Mana_base [i] *= 3;
			jugadorEstadisticas.Regeneracion_mana_base [i] *= 3;
		}
		jugadorEstadisticas.actualizarEstadisticasNivel ();
	}

	public void deshabilitarPasivaMago(){
		for (int i = 0; i < jugadorEstadisticas.Mana_base.Length; i++) {
			jugadorEstadisticas.Mana_base [i] /= 3;
			jugadorEstadisticas.Regeneracion_mana_base [i] /= 3;
		}
		jugadorEstadisticas.actualizarEstadisticasNivel ();
	}

	public void habilitarVampirismo(){
		tiene_vampirismo = true;
	}

	public void deshabilitarVampirismo(){
		tiene_vampirismo = false;
	}


	public bool Tiene_vampirismo {
		get {
			return this.tiene_vampirismo;
		}
		set {
			tiene_vampirismo = value;
		}
	}


}
