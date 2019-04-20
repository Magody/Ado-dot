using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolDefensa{

	Arbol arbol;
	private bool[] activados;
	//JugadorControlador player;

	public ArbolDefensa(bool[] act,JugadorControlador playerController){


		Nodo uno = new Nodo (1, "Puede usar escudo y armadura pesada",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "reduce todo DF: 20%",1); //fuerza física
		Nodo tres = new Nodo (3, "reduce todo DM: 20%",1); //fuerza mágica
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "Esquivar:10%, bloquear:10%",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{cuatro};
		Nodo cinco = new Nodo (5, "Habilidad: refleja un hechizo sacrificando un 5% de su vida",2);
		arbol.Raiz.Hijos [1].Hijos = new Nodo[]{cinco};

		Nodo seis = new Nodo (6, "Habilidad: escudo de llamas",3);
		arbol.Raiz.Hijos [0].Hijos[0].Hijos = new Nodo[]{ seis };
		arbol.Raiz.Hijos [1].Hijos[0].Hijos = arbol.Raiz.Hijos [0].Hijos; // apunto al mismo lugar

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
		if (activados [4]) {

		}
		if (activados [5]) {
			
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
		if (id == 5) {

		}
		if (id == 6) {

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
