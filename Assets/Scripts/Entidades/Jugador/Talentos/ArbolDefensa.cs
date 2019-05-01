using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolDefensa{

	Arbol arbol;
	private bool[] activados;

	JugadorEstadisticas jugadorEstadisticas;

	public ArbolDefensa(bool[] activados,Jugador jugador){


		Nodo uno = new Nodo (1, "habilidad: Puede usar escudo y armadura pesada",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "reduce todo daño fisico: 20%",1); //fuerza física
		Nodo tres = new Nodo (3, "reduce todo daño mágico: 20%",1); //fuerza mágica
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "Esquivar:10%, bloquear:10%",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{cuatro};
		Nodo cinco = new Nodo (5, "Habilidad: refleja un hechizo sacrificando un 5% de su vida",2);
		arbol.Raiz.Hijos [1].Hijos = new Nodo[]{cinco};

		Nodo seis = new Nodo (6, "Habilidad: escudo de llamas",3);
		arbol.Raiz.Hijos [0].Hijos[0].Hijos = new Nodo[]{ seis };
		arbol.Raiz.Hijos [1].Hijos[0].Hijos = arbol.Raiz.Hijos [0].Hijos; // apunto al mismo lugar

		//arbol.leerPorNivel ();
		this.activados = activados;

		jugadorEstadisticas = jugador.JugadorEstadisticas;
		activacionTalentos (jugador);
		//arbol.leerPorNivel ();

	}

	private void activacionTalentos(Jugador jugador){

		if (activados [0]) {
			
		}
		if (activados [1]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("DF", false, 20f);
		}
		if (activados [2]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("DM", false, 20f);
		}
		if (activados [3]) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("E", true, 0.1f);
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("B", true, 0.1f);
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
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("DF", false, 20f);
		}
		if (id == 3) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("DM", false, 20f);
		}
		if (id == 4) {
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("E", true, 0.1f);
			jugadorEstadisticas.modificarPermanentemenetEstadisticas ("B", true, 0.1f);
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

	public Arbol Arbol {
		get {
			return this.arbol;
		}
		set {
			arbol = value;
		}
	}

}
