using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola{

	Nodo inicio, final;

	public Cola ()
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





}
