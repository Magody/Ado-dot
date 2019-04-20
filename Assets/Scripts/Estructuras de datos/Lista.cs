using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista {

	Nodo inicio, final;

	public Lista ()
	{

	}

	public void push(Nodo dato){
		if (inicio == null) {
			inicio = dato;
			final = inicio;
		}else{
			final.Siguiente = dato;
			final = final.Siguiente;
		}
	}

	public Nodo pop(){
		Nodo dato = inicio;
		if(inicio != null)
			inicio = inicio.Siguiente;
		return dato;
	}

	public bool estaVacia(){
		return inicio == null;
	}

	public bool contiene(Nodo nodo){
		Nodo puntero = inicio;
		bool lo_contiene = false;
		while (puntero != null) {
			if (nodo == puntero) {
				lo_contiene = true;
				break;
			}
			puntero = puntero.Siguiente;
		}

		return lo_contiene;
	}

}
