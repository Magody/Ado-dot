using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructor : NPC {

	Lista listaInstrucciones;
	public string tipo;
	private string jugador_nombre;
	private string objeto_chocado;


	void Start () {

		jugador_nombre = FindObjectOfType<JugadorControlador> ().name;
		listaInstrucciones = new Lista ();

		if (tipo == "magia_destructiva") 
			iniciarMagiaDestruccion ();
		else if(tipo == "magia_sanadora")
			iniciarMagiaSanacion ();
		else if(tipo == "arte_marcial")
			iniciarArteMarcial ();
		else if(tipo == "armas")
			iniciarArmas ();
		else if(tipo == "ingenieria")
			iniciarIngeniería ();
	}


	
	// Update is called once per frame
	void Update () {

		if (objeto_chocado != null) {

			if (Input.GetKeyDown (KeyCode.E)) {
				if (!listaInstrucciones.estaVacia ()) {
					if (objeto_chocado == jugador_nombre) {
					
						DialogManager.IniciarDialogo (new string[]{ listaInstrucciones.pop ().Descripcion });
						
					}
				} else {
					DialogManager.IniciarDialogo (new string[]{ "Te he enseñado todo lo que se" });
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
