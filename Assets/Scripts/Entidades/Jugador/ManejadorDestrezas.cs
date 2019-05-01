using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDestrezas : MonoBehaviour {


	public const string MAGIA_DESTRUCCION = "magiaDestruccion";
	public const string MAGIA_SANACION = "magiaSanacion";
	public const string ARTE_MARCIAL = "arteMarcial";
	public const string ARMAS = "armas";
	public const string INGENIERIA = "ingenieria";

	private Lista destrezasMagiaDestruccion, destrezasMagiaSanacion, destrezasArteMarcial, destrezasArmas, destrezasIngenieria;


	private bool esta_entrenando;
	private string tema_entrenamiento;
	private int meta_entrenamiento;
	private int meta_entrenamiento_contador;


	// Use this for initialization
	void Start () {
		destrezasMagiaDestruccion = new Lista ();
		destrezasMagiaSanacion = new Lista ();
		destrezasArteMarcial = new Lista ();
		destrezasArmas = new Lista ();
		destrezasIngenieria  = new Lista ();


		iniciarMagiaDestruccion ();
		iniciarMagiaSanacion ();
		iniciarArteMarcial ();
		iniciarArmas ();
		iniciarIngeniería ();

	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKeyUp (KeyCode.Alpha1)) {
			entrenarDestreza (Destrezas.MAGIA_DESTRUCCION);
		}

		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			esta_entrenando = !esta_entrenando;
		}*/
	}

	public void entrenar(){

		if (esta_entrenando) {
			meta_entrenamiento_contador++;

			if (tema_entrenamiento == "FMD") {

				for (int i = 0; i < ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_magica_destructora_base.Length; i++) {
					ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_magica_destructora_base [i]++;
				}


			} else if (tema_entrenamiento == "FMS") {
			
				for (int i = 0; i < ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_magica_sanadora_base.Length; i++) {
					ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_magica_sanadora_base [i]++;
				}
			} else if (tema_entrenamiento == "FF") {

				for (int i = 0; i < ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_fisica_base.Length; i++) {
					ControladorGlobal.jugador.JugadorEstadisticas.Fuerza_fisica_base [i]++;
				}
			}

			ControladorGlobal.jugador.JugadorEstadisticas.actualizarEstadisticasNivel ();

			if (meta_entrenamiento_contador == meta_entrenamiento) {
				//acabó el entrenamiento
				esta_entrenando = false;
				ManejadorDialogos.IniciarDialogo (new string[]{ "Tema: " + tema_entrenamiento + " completado" });

			}
		}
	}

	public void entrenarNuevoNivelDestreza(string destreza){

		if (!esta_entrenando) {

			switch (destreza) {

			case MAGIA_DESTRUCCION:

				if (!destrezasMagiaDestruccion.estaVacia()) {
					string[] tokens = destrezasMagiaDestruccion.pop ().Descripcion.Split (':');
					tema_entrenamiento = tokens [0];
					if (tema_entrenamiento == "FMD") {
						meta_entrenamiento = int.Parse (tokens [1]);
						ManejadorDialogos.IniciarDialogo (new string[]{"Tema: " + tema_entrenamiento + ", numero de entrenamientos: " + meta_entrenamiento});

					} else if (tema_entrenamiento == "Habilidad") {
						meta_entrenamiento = 5;
						ManejadorDialogos.IniciarDialogo (new string[]{"Se ha entrenado la habilidad: " + tokens [1] + " y la tiene que usar " + meta_entrenamiento + " veces."});

					}

					esta_entrenando = true;
				} else {
					ManejadorDialogos.IniciarDialogo (new string[]{"El entrenamiento ha sido completado ya."});
				}
				break;

			case MAGIA_SANACION:
				
				break;

			case ARTE_MARCIAL:
				if (!destrezasArteMarcial.estaVacia()) {
					string[] tokens = destrezasArteMarcial.pop ().Descripcion.Split (':');
					tema_entrenamiento = tokens [0];
					if (tema_entrenamiento == "FF") {
						meta_entrenamiento = int.Parse (tokens [1]);
						ManejadorDialogos.IniciarDialogo (new string[]{"Tema: " + tema_entrenamiento + ", numero de entrenamientos: " + meta_entrenamiento});

					} else if (tema_entrenamiento == "Habilidad") {
						meta_entrenamiento = 5;
						ManejadorDialogos.IniciarDialogo (new string[]{"Se ha entrenado la habilidad: " + tokens [1] + " y la tiene que usar " + meta_entrenamiento + " veces."});

					}

					esta_entrenando = true;
				} else {
					ManejadorDialogos.IniciarDialogo (new string[]{"El entrenamiento ha sido completado ya."});
				}
				break;

			case ARMAS:
				
				break;

			case INGENIERIA:
				
				break;
			}


			meta_entrenamiento_contador = 0;
		}



	}




	private void iniciarMagiaDestruccion(){
		destrezasMagiaDestruccion.push(new Nodo("FMD:10"));
		destrezasMagiaDestruccion.push(new Nodo("Habilidad: bola de fuego"));
		destrezasMagiaDestruccion.push(new Nodo("FMD:20"));
		destrezasMagiaDestruccion.push(new Nodo("FMD:30"));
		destrezasMagiaDestruccion.push(new Nodo("Habilidad: retroceder en el tiempo"));
		destrezasMagiaDestruccion.push(new Nodo("FMD:50"));
		destrezasMagiaDestruccion.push(new Nodo("Habilidad: detener en el tiempo"));
	}

	private void iniciarMagiaSanacion(){
		destrezasMagiaSanacion.push(new Nodo("FMS:20"));
		destrezasMagiaSanacion.push(new Nodo("Habilidad: esperanza"));
		destrezasMagiaSanacion.push(new Nodo("FMS:30"));
		destrezasMagiaSanacion.push(new Nodo("FMS:50"));
		destrezasMagiaSanacion.push(new Nodo("Habilidad: rezo de escudo"));
		destrezasMagiaSanacion.push(new Nodo("FMS:100"));
		destrezasMagiaSanacion.push(new Nodo("Habilidad: sanación en masa"));
	}

	private void iniciarArteMarcial(){
		destrezasArteMarcial.push(new Nodo("FF:10"));
		destrezasArteMarcial.push(new Nodo("Habilidad: patada"));
		destrezasArteMarcial.push(new Nodo("FF:20"));
		destrezasArteMarcial.push(new Nodo("FF:30"));
		destrezasArteMarcial.push(new Nodo("Habilidad: salto"));
		destrezasArteMarcial.push(new Nodo("FF:50"));
		destrezasArteMarcial.push(new Nodo("Habilidad: onda de poder"));
	}

	private void iniciarArmas(){
		destrezasArmas.push(new Nodo("Armas tier:0"));
		destrezasArmas.push(new Nodo("Habilidad: giro espectacular"));
		destrezasArmas.push(new Nodo("Armas tier:1"));
		destrezasArmas.push(new Nodo("Armas tier:2"));
		destrezasArmas.push(new Nodo("Habilidad:encantador de armas"));
		destrezasArmas.push(new Nodo("Armas tier:3"));
		destrezasArmas.push(new Nodo("Habilidad:rabiar"));
	}

	private void iniciarIngeniería(){
		destrezasIngenieria.push(new Nodo("Componentes:0"));
		destrezasIngenieria.push(new Nodo("Habilidad:programador de robots simples"));
		destrezasIngenieria.push(new Nodo("Componentes:1"));
		destrezasIngenieria.push(new Nodo("Componentes:2"));
		destrezasIngenieria.push(new Nodo("Habilidad:programador de aviones"));
		destrezasIngenieria.push(new Nodo("Componentes:3"));
		destrezasIngenieria.push(new Nodo("Habilidad:creador de IA"));
	}

	public bool Esta_entrenando {
		get {
			return this.esta_entrenando;
		}
		set {
			esta_entrenando = value;
		}
	}

	public string Tema_entrenamiento {
		get {
			return this.tema_entrenamiento;
		}
		set {
			tema_entrenamiento = value;
		}
	}

	public int Meta_entrenamiento {
		get {
			return this.meta_entrenamiento;
		}
		set {
			meta_entrenamiento = value;
		}
	}

	public int Meta_entrenamiento_contador {
		get {
			return this.meta_entrenamiento_contador;
		}
		set {
			meta_entrenamiento_contador = value;
		}
	}
}
