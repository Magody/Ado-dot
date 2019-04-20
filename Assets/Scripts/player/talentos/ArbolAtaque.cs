﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolAtaque{

	Arbol arbol;
	private bool[] activados;
	JugadorControlador player;
	public ArbolAtaque(bool[] act,JugadorControlador playerController){


		Nodo uno = new Nodo (1, "CR: 80%",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "FF: 30%",1); //fuerza física
		Nodo tres = new Nodo (3, "FM: 50%",1); //fuerza mágica
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "Nuevo ataque: titan",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{cuatro};
		Nodo cinco = new Nodo (5, "Nuevo ataque: viajero",2);
		arbol.Raiz.Hijos [1].Hijos = new Nodo[]{cinco};

		//arbol.leerPorNivel ();
		this.activados = act;
		player = playerController;
		activacionTalentos (playerController);

		//arbol.leerPorNivel ();

	}

	private void activacionTalentos(JugadorControlador playerController){

		if (activados [0]) {
			playerController.JugadorEstadisticas.Critico += 80;
		}
		if (activados [1]) {
			playerController.JugadorEstadisticas.Fuerza_fisica_actual *= 1.3f;

		}
		if (activados [2]) {
			playerController.JugadorEstadisticas.Fuerza_magica_destructora_actual *= 1.5f;
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
			player.JugadorEstadisticas.Critico += 80;
		}
		if (id == 2) {
			player.JugadorEstadisticas.Fuerza_fisica_actual *= 1.3f;
		}
		if (id == 3) {
			player.JugadorEstadisticas.Fuerza_magica_destructora_actual *= 1.5f;
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
