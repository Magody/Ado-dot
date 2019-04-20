using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEstadisticas : MonoBehaviour {



	private float[] vida_base = new float[]{10, 50, 100, 150, 200, 250, 300, 500};
	private float vida_actual;
	private float[] mana_base = new float[]{0, 10, 25, 35, 45, 60, 70, 100};
	private float mana_actual;
	private float[] resistencia_base = new float[]{100, 100, 100, 100, 100, 100, 100, 100};
	private float resistencia_actual;
	private int[] experiencia_para_subir = new int[]{10, 20, 40, 80, 160, 320, 640, -1};
	private int experiencia_actual;
	private float critico;
	private float[] fuerza_fisica_base = new float[]{5, 10, 20, 30, 40, 50, 60, 100};
	private float fuerza_fisica_actual;
	private float[] fuerza_magica_destructora_base = new float[]{5, 10, 20, 30, 40, 50, 60, 100};
	private float fuerza_magica_destructora_actual;
	private float[] fuerza_magica_sanadora_base = new float[]{0, 0, 0, 0, 0, 0, 0, 0};
	private float fuerza_magica_sanadora_actual;
	private float[] defensa_base = new float[]{1, 1, 2, 3, 5, 8, 13, 21};
	private float defensa_actual;
	private float esquivar;
	private float bloquear;
	private float[] velocidad_movimiento_base = new float[]{5, 5, 5, 5, 5, 5, 5, 5};
	private float velocidad_movimiento_actual;
	private int nivel_actual;
	private Talentos talentos;

	public void iniciarEstadisticas(JugadorControlador playerController){
		talentos = gameObject.AddComponent<Talentos> ();
		actualizarEstadisticas ();
		talentos.iniciarTalentos (playerController);

	}

	private void actualizarEstadisticas(){
		vida_actual = vida_base [nivel_actual];
		mana_actual = mana_base [nivel_actual];
		resistencia_actual = resistencia_base [nivel_actual];
		fuerza_fisica_actual = fuerza_fisica_base [nivel_actual];
		fuerza_magica_destructora_actual = fuerza_magica_destructora_base [nivel_actual];
		fuerza_magica_sanadora_actual = fuerza_magica_sanadora_base [nivel_actual];
		defensa_actual = defensa_base [nivel_actual];
		velocidad_movimiento_actual = velocidad_movimiento_base [nivel_actual];
	}

	void Update () {

		if (nivel_actual < experiencia_para_subir.Length-1) {
			if (experiencia_actual >= experiencia_para_subir [nivel_actual]) {
				aumentarNivel ();
				talentos.Puntos_talento += 1;
			}
		}




	}

	private void aumentarNivel(){
		experiencia_actual -= experiencia_para_subir [nivel_actual];
		nivel_actual++;
		actualizarEstadisticas ();
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

	public float[] Defensa_base {
		get {
			return this.defensa_base;
		}
		set {
			defensa_base = value;
		}
	}

	public float Defensa_actual {
		get {
			return this.defensa_actual;
		}
		set {
			defensa_actual = value;
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




}
