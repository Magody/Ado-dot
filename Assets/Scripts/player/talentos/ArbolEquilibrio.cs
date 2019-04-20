using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolEquilibrio{

	Arbol arbol;
	private bool[] activados;
	//JugadorControlador player;

	public ArbolEquilibrio(bool[] act,JugadorControlador playerController){


		Nodo uno = new Nodo (1, "VM: +10%",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "habilidad: curación",1); //fuerza física
		Nodo tres = new Nodo (3, "habilidad: robo de vida",1); //fuerza mágica
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "habilidad: volar",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{ cuatro };
		arbol.Raiz.Hijos [1].Hijos = arbol.Raiz.Hijos [0].Hijos; // apunto al mismo lugar

		//arbol.leerPorNivel ();
		this.activados = act;
		//player = playerController;
		activacionTalentos (playerController);
		//arbol.leerPorNivel ();

	}

	private void activacionTalentos(JugadorControlador playerController){

		if (activados [0]) {

		}
		if (activados [1]) {


		}
		if (activados [2]) {

		}
		if (activados [3]) {

		}

	}

	public void renovar(int id){

		if (activados [id-1]) //no permite repetir la activación de un talento
			return;

		activados [id-1] = true;

		if (id == 1) {

		}
		if (id == 2) {

		}
		if (id == 3) {

		}
		if (id == 4) {

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
}
