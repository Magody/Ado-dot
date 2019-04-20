using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talentos : MonoBehaviour {


	ArbolAtaque arbolAtaque;
	ArbolDefensa arbolDefensa;
	ArbolEquilibrio arbolEquilibrio;

	JugadorControlador player;
	int puntos_talento = 100;

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

	public string leerInformacionTalento(string rama, int id){
		string salida = "";
		if (rama == "ataque")
			salida =  arbolAtaque.Arbol.buscarNodo (id).Descripcion;
		if(rama == "defensa")
			salida =  arbolDefensa.Arbol.buscarNodo (id).Descripcion;
		if(rama == "equilibrio")
			salida =  arbolEquilibrio.Arbol.buscarNodo (id).Descripcion;

		return salida;

	}

	public bool esPosibleRecoger(string rama, int id){

		bool esPosible = false;

		if (id == 1)
			return true;

		Lista padre;
		if (rama == "ataque") {
			
			padre = arbolAtaque.Arbol.obtenerPadres (id);

			if(padre != null) {
				Nodo puntero = padre.pop ();
				while (puntero != null) {

					esPosible = arbolAtaque.Activados [puntero.Id - 1];
					if (esPosible)
						return true;

					puntero = padre.pop ();
				}


			}
		}
		else if(rama == "defensa"){
			padre = arbolDefensa.Arbol.obtenerPadres (id);
			if(padre != null) {
				Nodo puntero = padre.pop ();
				while (puntero != null) {

					esPosible = arbolDefensa.Activados [puntero.Id - 1];
					if (esPosible)
						return true;

					puntero = padre.pop ();
				}
			}
		}
		else if(rama == "equilibrio"){
			padre = arbolEquilibrio.Arbol.obtenerPadres (id);
			if(padre != null) {
				Nodo puntero = padre.pop ();
				while (puntero != null) {

					esPosible = arbolEquilibrio.Activados [puntero.Id - 1];
					if (esPosible)
						return true;

					puntero = padre.pop ();
				}
			}
		}

		return esPosible;

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
