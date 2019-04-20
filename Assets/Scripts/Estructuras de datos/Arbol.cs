using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol{

	int numero_nodos;
	Nodo raiz;

	public Arbol (Nodo raiz)
	{
		this.raiz = raiz;
		numero_nodos = 0;
	}

	public void leerPorNivel(){


		Cola cola = new Cola ();
		Lista visitados = new Lista();

		cola.push (raiz);
		visitados.push (raiz);

		while(!cola.estaVacia()){
			Nodo puntero = cola.pop ();

			if(puntero.Hijos != null) 
				foreach (Nodo hijo in puntero.Hijos) {
					if (!visitados.contiene(hijo)) {
						cola.push (hijo);
						visitados.push (hijo);
					}
				}

			Debug.Log (puntero.Id + " -> " + puntero.Nivel);


		}


	}

	public Lista obtenerPadres(int id){

		Lista padre = new Lista();

		Cola cola = new Cola ();
		Lista visitados = new Lista();

		cola.push (raiz);
		visitados.push (raiz);

		while (!cola.estaVacia ()) {
			Nodo puntero = cola.pop ();

			if (puntero.Hijos != null) {
				foreach (Nodo hijo in puntero.Hijos) {
					if (!visitados.contiene (hijo)) {
						cola.push (hijo);
						visitados.push (hijo);
					}

					if (hijo.Id == id) {
						//Debug.Log (id + " su padre es " + puntero.Id);
						padre.push(puntero);
						
					}

				}

			}
		}

		return padre;

	}

	public Nodo Raiz {
		get {
			return this.raiz;
		}
		set {
			raiz = value;
		}
	}

	public int Numero_nodos {
		get {
			return this.numero_nodos;
		}
		set {
			numero_nodos = value;
		}
	}
	

}
