using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : NPC {

	public string tipo;
	public const string TIPO_MAGIA_DESTRUCCION = "magiaDestruccion";
	public const string TIPO_MAGIA_SANACION = "magiaSanacion";
	public const string TIPO_ARTE_MARCIAL = "arteMarcial";
	public const string TIPO_ARMAS = "armas";
	public const string TIPO_INGENIERIA = "ingenieria";

	private Lista listaInstrucciones;
	private string objeto_chocado;


	void Start () {
		
		listaInstrucciones = new Lista ();

		if (tipo == TIPO_MAGIA_DESTRUCCION) 
			iniciarMagiaDestruccion ();
		else if(tipo == TIPO_MAGIA_SANACION)
			iniciarMagiaSanacion ();
		else if(tipo == TIPO_ARTE_MARCIAL)
			iniciarArteMarcial ();
		else if(tipo == TIPO_ARMAS)
			iniciarArmas ();
		else if(tipo == TIPO_INGENIERIA)
			iniciarIngeniería ();
	}


	void Update () {

		if (objeto_chocado != null) {

			if (Input.GetKeyDown (KeyCode.E)) {
				if (!listaInstrucciones.estaVacia ()) {
					if (objeto_chocado == ControladorGlobal.jugador.name) {
					
						if (!ControladorGlobal.jugador.ManejadorDestrezas.Esta_entrenando) {
							ManejadorDialogos.IniciarDialogo (new string[]{ listaInstrucciones.pop ().Descripcion });
							ControladorGlobal.jugador.ManejadorDestrezas.entrenarNuevoNivelDestreza (tipo);
						} else {
							ManejadorDialogos.IniciarDialogo (new string[]{ "Sigue entrenando antes del siguiente nivel" });
						}
					}
				} else {
					ManejadorDialogos.IniciarDialogo (new string[]{ "Te he enseñado todo lo que se" });
				}
			}
		}



	}

	void OnTriggerEnter2D(Collider2D col){
		objeto_chocado = col.name;
		//print (this.gameObject.name + " chocó con " + objeto_chocado);
	}

	void OnTriggerExit2D(Collider2D col){
		objeto_chocado = null;
		//print (objeto_chocado + " se alejó ");
	}




	private void iniciarMagiaDestruccion(){
		listaInstrucciones.push(new Nodo("FMD: +10"));
		listaInstrucciones.push(new Nodo("Habilidad: bola de fuego"));
		listaInstrucciones.push(new Nodo("FMD: +20"));
		listaInstrucciones.push(new Nodo("FMD: +30"));
		listaInstrucciones.push(new Nodo("Habilidad: retroceder en el tiempo"));
		listaInstrucciones.push(new Nodo("FMD: +50"));
		listaInstrucciones.push(new Nodo("Habilidad: detener en el tiempo"));
	}

	private void iniciarMagiaSanacion(){
		listaInstrucciones.push(new Nodo("FMS: +20"));
		listaInstrucciones.push(new Nodo("Habilidad: esperanza"));
		listaInstrucciones.push(new Nodo("FMS: +30"));
		listaInstrucciones.push(new Nodo("FMS: +50"));
		listaInstrucciones.push(new Nodo("Habilidad: rezo de escudo"));
		listaInstrucciones.push(new Nodo("FMS: +100"));
		listaInstrucciones.push(new Nodo("Habilidad: sanación en masa"));
	}

	private void iniciarArteMarcial(){
		listaInstrucciones.push(new Nodo("FF: +10"));
		listaInstrucciones.push(new Nodo("Habilidad: patada"));
		listaInstrucciones.push(new Nodo("FF: +20"));
		listaInstrucciones.push(new Nodo("FF: +30"));
		listaInstrucciones.push(new Nodo("Habilidad: salto"));
		listaInstrucciones.push(new Nodo("FF: +50"));
		listaInstrucciones.push(new Nodo("Habilidad: onda de poder"));
	}

	private void iniciarArmas(){
		listaInstrucciones.push(new Nodo("Armas tier: 0"));
		listaInstrucciones.push(new Nodo("Habilidad: giro espectacular"));
		listaInstrucciones.push(new Nodo("Armas tier: 1"));
		listaInstrucciones.push(new Nodo("Armas tier: 2"));
		listaInstrucciones.push(new Nodo("Habilidad: encantador de armas"));
		listaInstrucciones.push(new Nodo("Armas tier: 3"));
		listaInstrucciones.push(new Nodo("Habilidad: rabiar"));
	}

	private void iniciarIngeniería(){
		listaInstrucciones.push(new Nodo("Componentes: 0"));
		listaInstrucciones.push(new Nodo("Habilidad: programador de robots simples"));
		listaInstrucciones.push(new Nodo("Componentes: 1"));
		listaInstrucciones.push(new Nodo("Componentes: 2"));
		listaInstrucciones.push(new Nodo("Habilidad: programador de aviones"));
		listaInstrucciones.push(new Nodo("Componentes: 3"));
		listaInstrucciones.push(new Nodo("Habilidad: creador de IA"));
	}



}
