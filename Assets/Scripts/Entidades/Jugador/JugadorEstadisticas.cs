using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEstadisticas : MonoBehaviour {


	private Talentos talentos;

	private float[] vida_base = new float[]{10, 50, 100, 150, 200, 250, 300, 500};
	private float vida_actual;
	private float modificacion_vida;

	private float[] mana_base = new float[]{0, 10, 25, 35, 45, 60, 70, 100};
	private float mana_actual;
	private float modificacion_mana;

	private float[] resistencia_base = new float[]{100, 100, 100, 100, 100, 100, 100, 100};
	private float resistencia_actual;
	private float modificacion_resistencia;

	private int[] experiencia_para_subir = new int[]{10, 20, 40, 80, 160, 320, 640, -1};
	private int experiencia_actual;
	private float modificacion_experiencia;

	private float critico;

	private float[] fuerza_fisica_base = new float[]{5, 10, 20, 30, 40, 50, 60, 100};
	private float fuerza_fisica_actual;
	private float modificacion_fuerza_fisica;

	private float[] fuerza_magica_destructora_base = new float[]{5, 10, 20, 30, 40, 50, 60, 100};
	private float fuerza_magica_destructora_actual;
	private float modificacion_fuerza_magica_destructora;

	private float[] fuerza_magica_sanadora_base = new float[]{0, 0, 0, 0, 0, 0, 0, 0};
	private float fuerza_magica_sanadora_actual;
	private float modificacion_fuerza_magica_sanadora;

	private float[] defensa_fisica_base = new float[]{1, 1, 2, 3, 5, 8, 13, 21};
	private float defensa_fisica_actual;
	private float modificacion_defensa_fisica;

	private float[] defensa_magica_base = new float[]{1, 1, 2, 3, 5, 8, 13, 21};
	private float defensa_magica_actual;
	private float modificacion_defensa_magica;

	private float esquivar;
	private float bloquear;

	private float[] regeneracion_vida_base = new float[]{1, 3, 5, 7, 9, 11, 13, 15};
	private float regeneracion_vida_actual;
	private float modificacion_regeneracion_vida;

	private float[] regeneracion_mana_base = new float[]{0, 0.5f, 1, 1.5f, 2, 2.5f, 3, 3.5f};
	private float regeneracion_mana_actual;
	private float modificacion_regeneracion_mana;

	private float[] regeneracion_resistencia_base = new float[]{10, 10, 10, 10, 10, 10, 10, 10};
	private float regeneracion_resistencia_actual;
	private float modificacion_regeneracion_resistencia;

	private float[] velocidad_movimiento_base = new float[]{5, 5, 5, 5, 5, 5, 5, 5};
	private float velocidad_movimiento_actual;

	private int nivel_actual;


	private float tiempo_regeneracion = 5;
	private float tiempo_regeneracion_contador = 5;


	public void iniciarEstadisticas(Jugador jugador){
		talentos = gameObject.AddComponent<Talentos> ();
		actualizarEstadisticasNivel ();
		talentos.iniciarTalentos (jugador);

	}

	void Update () {

		if (nivel_actual < experiencia_para_subir.Length-1) {
			if (experiencia_actual >= experiencia_para_subir [nivel_actual]) {
				aumentarNivel ();
				talentos.Puntos_talento += 1;
			}
		}

		//regeneración de estadisticas cada cierto tiempo
		tiempo_regeneracion_contador -= Time.deltaTime;

		if (tiempo_regeneracion_contador < 0) {
			
			if (vida_actual < vida_base [nivel_actual]) {
				regenerarVida ();
			}

			if (mana_actual < mana_base [nivel_actual]) {
				regenerarMana ();
			}

			if (regeneracion_resistencia_actual < regeneracion_resistencia_base [nivel_actual]) {
				regenerarResistencia ();
			}
			tiempo_regeneracion_contador = tiempo_regeneracion;
		}
			
		//print (velocidad_movimiento_actual);

	}

	public void modificarPermanentemenetEstadisticas(string estadistica,bool es_porcentual,float valor){

		//toda variable modificación es porcentural
		if (es_porcentual) {
			
			switch (estadistica) {
			case "V":
				modificacion_vida = valor;
				break;
			case "M":
				modificacion_mana = valor;
				break;
			case "R":
				modificacion_resistencia = valor;
				break;
			case "CR":
				critico = valor * 100;
				break;
			case "FF":
				modificacion_fuerza_fisica = valor;
				break;
			case "FMD":
				modificacion_fuerza_magica_destructora = valor;
				break;
			case "FMS":
				modificacion_fuerza_magica_sanadora = valor;
				break;
			case "DF":
				modificacion_defensa_fisica = valor;
				break;
			case "DM":
				modificacion_defensa_magica = valor;
				break;
			case "E":
				esquivar = valor * 100;
				break;
			case "B":
				bloquear = valor * 100;
				break;
			case "RV":
				modificacion_regeneracion_vida = valor;
				break;
			case "RM":
				modificacion_regeneracion_mana = valor;
				break;
			case "RR":
				modificacion_regeneracion_resistencia = valor;
				break;
			case "VM":
				Debug.Log ("Solo se hacen cambios directos a la velocidad de movimiento");
				break;
			}
		} else {
			//es un cambio directo a los valores base
			switch (estadistica) {
			case "V":
				for(int i=0; i<vida_base.Length;i++) {
					vida_base [i] = vida_base [i] + valor;
				}
				break;
			case "M":
				for(int i=0; i<mana_base.Length;i++) {
					mana_base [i] = mana_base [i] + valor;
				}
				break;
			case "R":
				for(int i=0; i<resistencia_base.Length;i++) {
					resistencia_base [i] = resistencia_base [i] + valor;
				}
				break;
			case "CR":
				Debug.Log ("Solo se hacen cambios porcentuales al crítico");
				break;
			case "FF":
				for(int i=0; i<fuerza_fisica_base.Length;i++) {
					fuerza_fisica_base [i] = fuerza_fisica_base [i] + valor;
				}
				break;
			case "FMD":
				for(int i=0; i<fuerza_magica_destructora_base.Length;i++) {
					fuerza_magica_destructora_base [i] = fuerza_magica_destructora_base [i] + valor;
				}
				break;
			case "FMS":
				for(int i=0; i<fuerza_magica_sanadora_base.Length;i++) {
					fuerza_magica_sanadora_base [i] = fuerza_magica_sanadora_base [i] + valor;
				}
				break;
			case "DF":
				for(int i=0; i<defensa_fisica_base.Length;i++) {
					defensa_fisica_base [i] = defensa_fisica_base [i] + valor;
				}
				break;
			case "DM":
				for(int i=0; i<defensa_magica_base.Length;i++) {
					defensa_magica_base [i] = defensa_magica_base [i] + valor;
				}
				break;
			case "E":
				Debug.Log ("Solo se hacen cambios porcentuales al esquivar");
				break;
			case "B":
				Debug.Log ("Solo se hacen cambios porcentuales al bloquear");
				break;
			case "RV":
				for(int i=0; i<regeneracion_vida_base.Length;i++) {
					regeneracion_vida_base [i] = regeneracion_vida_base [i] + valor;
				}
				break;
			case "RM":
				for(int i=0; i<regeneracion_mana_base.Length;i++) {
					regeneracion_mana_base [i] = regeneracion_mana_base [i] + valor;
				}
				break;
			case "RR":
				for(int i=0; i<regeneracion_resistencia_base.Length;i++) {
					regeneracion_resistencia_base [i] = regeneracion_resistencia_base [i] + valor;
				}
				break;
			case "VM":
				
				for(int i=0; i<velocidad_movimiento_base.Length;i++) {
					velocidad_movimiento_base [i] = velocidad_movimiento_base [i] + valor;
				}

				break;
			}
		}

		actualizarEstadisticasNivel ();


	}


	private void regenerarVida(){

		if (vida_actual + regeneracion_vida_actual < vida_base [nivel_actual]) {
			vida_actual += regeneracion_vida_actual;
		} else {
			vida_actual = vida_base [nivel_actual];
		}
	}

	private void regenerarMana(){

		if (mana_actual + regeneracion_mana_actual < mana_base [nivel_actual]) {
			mana_actual += regeneracion_mana_actual;
		} else {
			mana_actual = mana_base [nivel_actual];
		}
	}

	private void regenerarResistencia(){

		if (regeneracion_resistencia_actual + regeneracion_resistencia_actual < regeneracion_resistencia_base [nivel_actual]) {
			regeneracion_resistencia_actual += regeneracion_vida_actual;
		} else {
			regeneracion_resistencia_actual = regeneracion_resistencia_base [nivel_actual];
		}
	}

	public void aplicarSanacion(float sanacion){

		if (vida_actual + sanacion >= vida_base [nivel_actual]) {
			vida_actual = vida_base [nivel_actual];
		} else {
			vida_actual += sanacion;
		}

	}


	private void aumentarNivel(){
		experiencia_actual -= experiencia_para_subir [nivel_actual];
		nivel_actual++;
		actualizarEstadisticasNivel ();
	}

	public void actualizarEstadisticasNivel(){
		vida_actual = vida_base [nivel_actual] + modificacion_vida*vida_base [nivel_actual];
		mana_actual = mana_base [nivel_actual] + modificacion_mana*mana_base[nivel_actual];
		resistencia_actual = resistencia_base [nivel_actual] + modificacion_resistencia*resistencia_base[nivel_actual];
		fuerza_fisica_actual = fuerza_fisica_base [nivel_actual]+modificacion_fuerza_fisica*fuerza_fisica_base[nivel_actual];
		fuerza_magica_destructora_actual = fuerza_magica_destructora_base [nivel_actual]+modificacion_fuerza_magica_destructora*fuerza_magica_destructora_base [nivel_actual];
		fuerza_magica_sanadora_actual = fuerza_magica_sanadora_base [nivel_actual]+modificacion_fuerza_magica_sanadora*fuerza_magica_sanadora_base [nivel_actual];
		defensa_fisica_actual = defensa_fisica_base [nivel_actual]+modificacion_defensa_fisica*defensa_fisica_base [nivel_actual];
		defensa_magica_actual = defensa_magica_base [nivel_actual]+modificacion_defensa_magica*defensa_magica_base [nivel_actual];
		regeneracion_vida_actual = regeneracion_vida_base[nivel_actual]+modificacion_regeneracion_vida*regeneracion_vida_base[nivel_actual];
		regeneracion_mana_actual = regeneracion_mana_base[nivel_actual]+modificacion_regeneracion_mana*regeneracion_mana_base[nivel_actual];
		regeneracion_resistencia_actual = regeneracion_resistencia_base[nivel_actual]+modificacion_regeneracion_resistencia*regeneracion_resistencia_base[nivel_actual];
		velocidad_movimiento_actual = velocidad_movimiento_base [nivel_actual];

		if (ControladorGlobal.jugador.ArmaActual != null) {
			if (ControladorGlobal.jugador.ArmaActual.Tipo == Arma.TIPO_ESPADA) {
				ControladorGlobal.jugador.ArmaActual.gameObject.GetComponent<ControladorEspada> ().actualizarDanio ();
			}
		}
	}

	public string leerResumenEstadisticas(){
		string salida = "";

		salida += "V: " + vida_actual;
		salida += "\nM: " + mana_actual; //no usada
		salida += "\nR: " + resistencia_actual; //no usada
		salida += "\nEXP: " + experiencia_para_subir[nivel_actual];
		salida += "\nEXP Actual: " + experiencia_actual;
		salida += "\nCR: " + critico;
		salida += "\nFF: " + fuerza_fisica_actual;
		salida += "\nFMD: " + fuerza_magica_destructora_actual; //no usada
		salida += "\nFMS: " + fuerza_magica_sanadora_actual; //no usada
		salida += "\nE: " + esquivar;
		salida += "\nB: " + bloquear; //no usada
		salida += "\nDF: " + defensa_fisica_actual;
		salida += "\nDM: " + defensa_magica_actual; 
		salida += "\nRV: " + regeneracion_vida_actual;
		salida += "\nRM: " + regeneracion_mana_actual;
		salida += "\nRR: " + regeneracion_resistencia_actual;
		salida += "\nVM: " + velocidad_movimiento_actual;
		return salida;
	}

	public float[] Vida_base {
		get {
			return this.vida_base;
		}
		set {
			vida_base = value;
		}
	}

	public float Vida_actual {
		get {
			return this.vida_actual;
		}
		set {
			vida_actual = value;
		}
	}

	public float[] Mana_base {
		get {
			return this.mana_base;
		}
		set {
			mana_base = value;
		}
	}

	public float Mana_actual {
		get {
			return this.mana_actual;
		}
		set {
			mana_actual = value;
		}
	}

	public float[] Resistencia_base {
		get {
			return this.resistencia_base;
		}
		set {
			resistencia_base = value;
		}
	}

	public float Resistencia_actual {
		get {
			return this.resistencia_actual;
		}
		set {
			resistencia_actual = value;
		}
	}

	public int[] Experiencia_para_subir {
		get {
			return this.experiencia_para_subir;
		}
		set {
			experiencia_para_subir = value;
		}
	}

	public int Experiencia_actual {
		get {
			return this.experiencia_actual;
		}
		set {
			experiencia_actual = value;
		}
	}

	public float Critico {
		get {
			return this.critico;
		}
		set {
			critico = value;
		}
	}

	public float[] Fuerza_fisica_base {
		get {
			return this.fuerza_fisica_base;
		}
		set {
			fuerza_fisica_base = value;
		}
	}

	public float Fuerza_fisica_actual {
		get {
			return this.fuerza_fisica_actual;
		}
		set {
			fuerza_fisica_actual = value;
		}
	}

	public float[] Fuerza_magica_destructora_base {
		get {
			return this.fuerza_magica_destructora_base;
		}
		set {
			fuerza_magica_destructora_base = value;
		}
	}

	public float Fuerza_magica_destructora_actual {
		get {
			return this.fuerza_magica_destructora_actual;
		}
		set {
			fuerza_magica_destructora_actual = value;
		}
	}

	public float[] Fuerza_magica_sanadora_base {
		get {
			return this.fuerza_magica_sanadora_base;
		}
		set {
			fuerza_magica_sanadora_base = value;
		}
	}

	public float Fuerza_magica_sanadora_actual {
		get {
			return this.fuerza_magica_sanadora_actual;
		}
		set {
			fuerza_magica_sanadora_actual = value;
		}
	}

	public float[] Defensa_fisica_base {
		get {
			return this.defensa_fisica_base;
		}
		set {
			defensa_fisica_base = value;
		}
	}

	public float Defensa_fisica_actual {
		get {
			return this.defensa_fisica_actual;
		}
		set {
			defensa_fisica_actual = value;
		}
	}

	public float Esquivar {
		get {
			return this.esquivar;
		}
		set {
			esquivar = value;
		}
	}

	public float Bloquear {
		get {
			return this.bloquear;
		}
		set {
			bloquear = value;
		}
	}

	public float[] Velocidad_movimiento_base {
		get {
			return this.velocidad_movimiento_base;
		}
		set {
			velocidad_movimiento_base = value;
		}
	}

	public float Velocidad_movimiento_actual {
		get {
			return this.velocidad_movimiento_actual;
		}
		set {
			velocidad_movimiento_actual = value;
		}
	}

	public int Nivel_actual {
		get {
			return this.nivel_actual;
		}
		set {
			nivel_actual = value;
		}
	}

	public Talentos Talentos {
		get {
			return this.talentos;
		}
		set {
			talentos = value;
		}
	}

	public float[] Defensa_magica_base {
		get {
			return this.defensa_magica_base;
		}
		set {
			defensa_magica_base = value;
		}
	}

	public float Defensa_magica_actual {
		get {
			return this.defensa_magica_actual;
		}
		set {
			defensa_magica_actual = value;
		}
	}

	public float[] Regeneracion_vida_base {
		get {
			return this.regeneracion_vida_base;
		}
		set {
			regeneracion_vida_base = value;
		}
	}

	public float Regeneracion_vida_actual {
		get {
			return this.regeneracion_vida_actual;
		}
		set {
			regeneracion_vida_actual = value;
		}
	}

	public float[] Regeneracion_mana_base {
		get {
			return this.regeneracion_mana_base;
		}
		set {
			regeneracion_mana_base = value;
		}
	}

	public float Regeneracion_mana_actual {
		get {
			return this.regeneracion_mana_actual;
		}
		set {
			regeneracion_mana_actual = value;
		}
	}

	public float[] Regeneracion_resistencia_base {
		get {
			return this.regeneracion_resistencia_base;
		}
		set {
			regeneracion_resistencia_base = value;
		}
	}

	public float Regeneracion_resistencia_actual {
		get {
			return this.regeneracion_resistencia_actual;
		}
		set {
			regeneracion_resistencia_actual = value;
		}
	}

}
