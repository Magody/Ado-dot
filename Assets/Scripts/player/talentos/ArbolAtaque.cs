using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolAtaque{

	Arbol arbol;
	private bool[] activados;

	JugadorEstadisticas jugadorEstadisticas;

	public ArbolAtaque(bool[] act,JugadorControlador jugadorControlador){


		Nodo uno = new Nodo (1, "CR: 80%",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "FF: 30%",1); //fuerza física
		Nodo tres = new Nodo (3, "FMD: 50%",1); //fuerza mágica
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "habilidad: titan",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{cuatro};
		Nodo cinco = new Nodo (5, "habilidad: volar",2);
		arbol.Raiz.Hijos [1].Hijos = new Nodo[]{cinco};

		this.activados = act;
		activacionTalentos (jugadorControlador);
		jugadorEstadisticas = jugadorControlador.JugadorEstadisticas;

	}

	private void activacionTalentos(JugadorControlador playerController){

		if (activados [0]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("CR", true, 0.8f);
		}
		if (activados [1]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("FF", true, 0.3f);
		}
		if (activados [2]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("FMD", true, 0.5f);
		}
		if (activados [3]) {

		}
		if (activados [4]) {

		}

	}

	public void renovar(int id){

		if (activados [id-1]) //no permite repetir la activación de un talento
			return;
		
		activados [id-1] = true;

		if (id == 1) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("CR", true, 0.8f);
		}
		if (id == 2) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("FF", true, 0.3f);
		}
		if (id == 3) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("FMD", true, 0.5f);
		}
		if (id == 4) {

		}
		if (id == 5) {

		}

	}


	public bool[] Activados {
		get {
			return this.activados;
		}
		set {
			activados = value;
		}
	}

	public Arbol Arbol {
		get {
			return this.arbol;
		}
		set {
			arbol = value;
		}
	}

}
