using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainDebug : MonoBehaviour {


	//int contador = 0;
	//Cola cola;
	Arbol arbol;


	void Start () {
		//cola = new Cola ();


		Nodo uno = new Nodo (1, "CR: 25%",0);
		arbol = new Arbol (uno);
		Nodo dos = new Nodo (2, "DF: 30%",1);
		Nodo tres = new Nodo (3, "DM: 50%",1);
		arbol.Raiz.Hijos = new Nodo[]{dos,tres};
		Nodo cuatro = new Nodo (4, "Nuevo ataque: titan",2);
		arbol.Raiz.Hijos [0].Hijos = new Nodo[]{cuatro};
		Nodo cinco = new Nodo (5, "Nuevo ataque: viajero",2);
		arbol.Raiz.Hijos [1].Hijos = new Nodo[]{cinco};

		arbol.leerPorNivel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			
			/*print ("PUSH");
			cola.push (""+(contador++));*/
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			/*print ("POP");
			print(cola.pop ());*/

		}
	}





}
