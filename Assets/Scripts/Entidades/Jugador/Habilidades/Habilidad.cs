using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Habilidad : MonoBehaviour {


	protected Jugador jugador;
	protected JugadorEstadisticas jugadorEstadisticas;
	protected GameObject prefab_efecto;
	protected string nombre;
	protected string descripcion;
	protected float costo_mana;
	protected float costo_resistencia;
	protected float tiempo_duracion_base;
	protected float tiempo_duracion_contador;
	protected float tiempo_reutilizacion_base;
	protected float tiempo_reutilizacion_contador;
	protected bool esta_activada;
	protected bool esta_reutilizacion;

	public abstract void activar();

	public void SuperStart(){
		jugador = ControladorGlobal.jugador;
		jugadorEstadisticas = jugador.JugadorEstadisticas;
	}

	public string Nombre {
		get {
			return this.nombre;
		}
		set {
			nombre = value;
		}
	}

	public string Descripcion {
		get {
			return this.descripcion;
		}
		set {
			descripcion = value;
		}
	}

	public float Tiempo_duracion_base {
		get {
			return this.tiempo_duracion_base;
		}
		set {
			tiempo_duracion_base = value;
		}
	}

	public float Tiempo_duracion_contador {
		get {
			return this.tiempo_duracion_contador;
		}
		set {
			tiempo_duracion_contador = value;
		}
	}

	public float Tiempo_reutilizacion_base {
		get {
			return this.tiempo_reutilizacion_base;
		}
		set {
			tiempo_reutilizacion_base = value;
		}
	}

	public float Tiempo_reutilizacion_contador {
		get {
			return this.tiempo_reutilizacion_contador;
		}
		set {
			tiempo_reutilizacion_contador = value;
		}
	}

}
