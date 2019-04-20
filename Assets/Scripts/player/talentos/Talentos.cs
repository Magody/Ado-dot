using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talentos : MonoBehaviour {


	ArbolAtaque arbolAtaque;
	ArbolDefensa arbolDefensa;
	ArbolEquilibrio arbolEquilibrio;

	JugadorControlador player;
	int puntos_talento;

	public void iniciarTalentos(JugadorControlador player){
		
		arbolAtaque = new ArbolAtaque (new bool[]{false,false,false,false,false},player);
		arbolDefensa = new ArbolDefensa (new bool[]{false,false,false,false,false,false},player);
		arbolEquilibrio = new ArbolEquilibrio (new bool[]{false,false,false,false},player);


	}

	public void renovarTalentos(int id_activacion, string rama){
		if(rama == "ataque")
			arbolAtaque.renovar(id_activacion);
		if(rama == "defensa")
			arbolDefensa.renovar(id_activacion);
		if(rama == "equilibrio")
			arbolEquilibrio.renovar(id_activacion);
	}


	public ArbolAtaque ArbolAtaque {
		get {
			return this.arbolAtaque;
		}
		set {
			arbolAtaque = value;
		}
	}

	public ArbolDefensa ArbolDefensa {
		get {
			return this.arbolDefensa;
		}
		set {
			arbolDefensa = value;
		}
	}

	public ArbolEquilibrio ArbolEquilibrio {
		get {
			return this.arbolEquilibrio;
		}
		set {
			arbolEquilibrio = value;
		}
	}

	public int Puntos_talento {
		get {
			return this.puntos_talento;
		}
		set {
			puntos_talento = value;
		}
	}
}
