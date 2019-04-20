using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo{

	int id;
	string descripcion;
	int nivel;
	Nodo siguiente;
	Nodo[] hijos;


	public Nodo (int id, string descripcion,int nivel)
	{
		this.descripcion = descripcion;
		this.id = id;
		this.nivel = nivel;
	}

	public Nodo (string descripcion)
	{
		this.descripcion = descripcion;
		this.siguiente = null;
	}

	public string Descripcion {
		get {
			return this.descripcion;
		}
		set {
			descripcion = value;
		}
	}

	public int Id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public int Nivel {
		get {
			return this.nivel;
		}
		set {
			nivel = value;
		}
	}


	public Nodo Siguiente {
		get {
			return this.siguiente;
		}
		set {
			siguiente = value;
		}
	}

	public Nodo[] Hijos {
		get {
			return this.hijos;
		}
		set {
			hijos = value;
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Nodo: descripcion={0}, siguiente={1}]", descripcion, siguiente);
	}
	

}
