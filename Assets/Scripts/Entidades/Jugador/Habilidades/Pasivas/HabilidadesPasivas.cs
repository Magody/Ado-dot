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

	public void habilitarPasivaPersistencia(){
		
		for (int i = 0; i < jugadorEstadisticas.Resistencia_base.Length; i++) {
			jugadorEstadisticas.Resistencia_base [i] *= 3;
		}
		jugadorEstadisticas.actualizarEstadisticasNivel ();
	}

	public void deshabilitarPasivaPersistencia(){
		for (int i = 0; i < jugadorEstadisticas.Resistencia_base.Length; i++) {
			jugadorEstadisticas.Resistencia_base [i] /= 3;
		}
		jugadorEstadisticas.actualizarEstadisticasNivel ();
	}

	public void habilitarPasivaVampirismo(){
		tiene_vampirismo = true;
	}

	public void deshabilitarPasivaVampirismo(){
		tiene_vampirismo = false;
	}

	public void habilitarPasivaEncantadorArmas(string encantamiento){
		if (ControladorGlobal.jugador.ArmaActual.Tipo == Arma.TIPO_ESPADA) {
			ControladorGlobal.jugador.ArmaActual.Encantamiento = encantamiento;
		}
	}

	public void deshabilitarPasivaEncantadorArmas(){
		if (ControladorGlobal.jugador.ArmaActual.Tipo == Arma.TIPO_ESPADA) {
			ControladorGlobal.jugador.ArmaActual.Encantamiento = Arma.ENCANTAMIENTO_NINGUNO;
		}
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
