using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

	private static bool existe_jugador;

	public bool tiene_arma;

	private JugadorEstadisticas jugadorEstadisticas;
	private JugadorEstado jugadorEstado;
	private Habilidad[] habilidadesActivas;
	private HabilidadesPasivas manejadorHabilidadesPasivas;
	private ManejadorDestrezas manejadorDestrezas;

	private Vector2 axis; //si es horizontal o vertical actualmente
	private Vector2 axisUltimo; //para la direccion del movimiento
	private Vector3 posicionInicial;
	private SpriteRenderer spriteRenderer; // para el cambio de color
	private GameObject arma;
	private Arma armaActual;
	private Animator animator;
	private Rigidbody2D rb;

	private bool puede_moverse;
	private bool esta_vivo;
	private float monedas;


	void Start () {

		if (!Jugador.existe_jugador) {
			Jugador.existe_jugador = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}

		jugadorEstadisticas = gameObject.AddComponent <JugadorEstadisticas>();
		jugadorEstado = gameObject.AddComponent <JugadorEstado>();
		habilidadesActivas = new Habilidad[20];
		manejadorHabilidadesPasivas = new HabilidadesPasivas (jugadorEstadisticas);
		manejadorDestrezas = gameObject.AddComponent<ManejadorDestrezas> ();
		arma = GameObject.Find ("Weapon");

		this.axisUltimo.y = -1;
		posicionInicial = new Vector3 (28.71f, -14.3f, 0f);
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

		esta_vivo = true;

		jugadorEstadisticas.iniciarEstadisticas(this);
		jugadorEstado.iniciarEstado (JugadorEstado.QUIETO,this);

		habilidadesActivas [0] = gameObject.AddComponent<HBolaDeFuego> ();
		habilidadesActivas [1] = gameObject.AddComponent<HCuracion> ();
		habilidadesActivas [2] = gameObject.AddComponent<HEscudoDeLlamas> ();
		habilidadesActivas [3] = gameObject.AddComponent<HEsperanza> ();
		habilidadesActivas [4] = gameObject.AddComponent<HRabiar> ();
		habilidadesActivas [5] = gameObject.AddComponent<HDetenerTiempo> ();
	}

	void Update () {
		
		arma.gameObject.SetActive (tiene_arma);

		if (tiene_arma && armaActual == null) {
			armaActual = FindObjectOfType<Arma> ();

		} else if(!tiene_arma){
			armaActual = null;
		}

		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			habilidadesActivas [0].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			habilidadesActivas [1].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha3)) {
			habilidadesActivas [2].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha4)) {
			habilidadesActivas [3].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha5)) {
			habilidadesActivas [4].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Alpha6)) {
			habilidadesActivas [5].activar ();
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			manejadorHabilidadesPasivas.habilitarPasivaPersistencia ();
			manejadorHabilidadesPasivas.habilitarPasivaEncantadorArmas (Arma.ENCANTAMIENTO_FUEGO);
			manejadorHabilidadesPasivas.habilitarPasivaVampirismo ();
			//habilidades_pasivas.habilitarPasivaMago ();
		}
		if (Input.GetKeyUp (KeyCode.X)) {
			manejadorHabilidadesPasivas.deshabilitarPasivaPersistencia ();
			manejadorHabilidadesPasivas.deshabilitarPasivaEncantadorArmas ();
			manejadorHabilidadesPasivas.deshabilitarPasivaVampirismo ();
			//habilidades_pasivas.deshabilitarPasivaMago ();
		}
	}


	void aplicarDanio(string[] danioYtipo){

		if (jugadorEstado.Estado_actual != JugadorEstado.HERIDO) {
			
			var clone = (GameObject)Instantiate (ControladorGlobal.PREFAB_TEXTO_FLOTANTE, transform.position, Quaternion.Euler (Vector3.zero));

			if (Random.Range (1, 101) > jugadorEstadisticas.Esquivar) { 

				float danio = float.Parse (danioYtipo [0]);

				if (danioYtipo [1] == ControladorGlobal.STRING_DANIO_FISICO) {

					danio -= (danio * jugadorEstadisticas.Defensa_fisica_actual / 100);

					if (jugadorEstadisticas.Vida_actual - danio >= 0) {
						jugadorEstadisticas.Vida_actual -= danio;

					} else
						jugadorEstadisticas.Vida_actual = 0;


					jugadorEstado.Estado_actual = JugadorEstado.HERIDO;
					ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_JUGADOR_HERIDO);
					spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

					Instantiate (ControladorGlobal.PREFAB_SANGRE_ROJA, transform.position, transform.rotation);
					clone.GetComponent<TextoFlotante> ().Texto = "" + danio;
					clone.GetComponent<TextoFlotante> ().Text.color = Color.grey;


				} else if (danioYtipo [1] == ControladorGlobal.STRING_DANIO_MAGICO) {

					danio -= (danio * jugadorEstadisticas.Defensa_magica_actual / 100);


					if (jugadorEstadisticas.Vida_actual - danio >= 0) {
						jugadorEstadisticas.Vida_actual -= danio;

					} else
						jugadorEstadisticas.Vida_actual = 0;


					jugadorEstado.Estado_actual = JugadorEstado.HERIDO;
					ControladorGlobal.manejadorSFX.reproducirSFX (ManejadorSFX.SFX_JUGADOR_HERIDO);
					spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

					Instantiate (ControladorGlobal.PREFAB_SANGRE_ROJA, transform.position, transform.rotation);
					clone.GetComponent<TextoFlotante> ().Texto = "" + danio;
					clone.GetComponent<TextoFlotante> ().Text.color = Color.magenta;


				}

			} else {
				clone.GetComponent<TextoFlotante> ().Texto = "Esquivado";
				clone.GetComponent<TextoFlotante> ().Text.color = Color.green;

			}
		}


	}

	//public float x=10, y=10, ancho=10, alto=10;
	//public float x2=10, y2=10, ancho2=10, alto2=10;
	public float offsetx = 25;
	public float offsetancho = 25;
	void OnGUI(){
		
		if(GUI.Button(new Rect(206,670,45+offsetancho,45),"BolaFuego"))
			habilidadesActivas [0].activar ();
		if(GUI.Button(new Rect(256+offsetx,670,45+offsetancho,45),"Curacion"))
			habilidadesActivas [1].activar ();
		if(GUI.Button(new Rect(306+offsetx*2,670,45+offsetancho,45),"EscudoF"))
			habilidadesActivas [2].activar ();
		if(GUI.Button(new Rect(356+offsetx*3,670,45+offsetancho,45),"Esperanza"))
			habilidadesActivas [3].activar ();
		if(GUI.Button(new Rect(406+offsetx*4,670,45+offsetancho,45),"Rabiar"))
			habilidadesActivas [4].activar ();
		if(GUI.Button(new Rect(456+offsetx*5,670,45+offsetancho,45),"Tiempo"))
			habilidadesActivas [5].activar ();
		if(GUI.Button(new Rect(506+offsetx*6,670,45+offsetancho,45),""))
			habilidadesActivas [6].activar ();
		if(GUI.Button(new Rect(556+offsetx*7,670,45+offsetancho,45),""))
			habilidadesActivas [7].activar ();
		if(GUI.Button(new Rect(606+offsetx*8,670,45+offsetancho,45),""))
			habilidadesActivas [8].activar ();
		if(GUI.Button(new Rect(656+offsetx*9,670,45+offsetancho,45),""))
			habilidadesActivas [9].activar ();

		if(GUI.Button(new Rect(206,670+50,45+offsetancho,45),""))
			habilidadesActivas [10].activar ();
		if(GUI.Button(new Rect(256+offsetx,670+50,45+offsetancho,45),""))
			habilidadesActivas [11].activar ();
		if(GUI.Button(new Rect(306+offsetx*2,670+50,45+offsetancho,45),""))
			habilidadesActivas [12].activar ();
		if(GUI.Button(new Rect(356+offsetx*3,670+50,45+offsetancho,45),""))
			habilidadesActivas [13].activar ();
		if(GUI.Button(new Rect(406+offsetx*4,670+50,45+offsetancho,45),""))
			habilidadesActivas [14].activar ();
		if(GUI.Button(new Rect(456+offsetx*5,670+50,45+offsetancho,45),""))
			habilidadesActivas [15].activar ();
		if(GUI.Button(new Rect(506+offsetx*6,670+50,45+offsetancho,45),""))
			habilidadesActivas [16].activar ();
		if(GUI.Button(new Rect(556+offsetx*7,670+50,45+offsetancho,45),""))
			habilidadesActivas [17].activar ();
		if(GUI.Button(new Rect(606+offsetx*8,670+50,45+offsetancho,45),"NIVEL")){
			jugadorEstadisticas.Nivel_actual = 7; jugadorEstadisticas.actualizarEstadisticasNivel ();
		}
		if (GUI.Button (new Rect (656 + offsetx * 9, 670 + 50, 45 + offsetancho, 45), "RESTATUS"))
			jugadorEstadisticas.actualizarEstadisticasNivel ();

	}


	//GETTERS SETTERS
	public JugadorEstadisticas JugadorEstadisticas {		get {			return this.jugadorEstadisticas;		}		set {			jugadorEstadisticas = value;		}	}

	public Vector2 AxisUltimo {		get {			return this.axisUltimo;		}		set {			axisUltimo = value;		}	}

	public Vector2 Axis {		get {			return this.axis;		}		set {			axis = value;		}	}

	public Animator Animator {		get {			return this.animator;		}		set {			animator = value;		}	}

	public Rigidbody2D Rb {		get {			return this.rb;		}		set {			rb = value;		}	}

	public bool Puede_moverse {		get {			return this.puede_moverse;		}		set {			puede_moverse = value;		}	}

	public bool Esta_vivo {		get {			return this.esta_vivo;		}		set {			esta_vivo = value;		}	}

	public Vector3 Posicion_inicial {		get {			return this.posicionInicial;		}		set {			posicionInicial = value;		}	}

	public SpriteRenderer SpriteRenderer {		get {			return this.spriteRenderer;		}		set {			spriteRenderer = value;		}	}

	public JugadorEstado JugadorEstado {		get {			return this.jugadorEstado;		}		set {			jugadorEstado = value;		}	}

	public bool Tiene_arma {
		get {
			return this.tiene_arma;
		}
		set {
			tiene_arma = value;
		}
	}

	public ManejadorDestrezas ManejadorDestrezas {
		get {
			return this.manejadorDestrezas;
		}
		set {
			manejadorDestrezas = value;
		}
	}

	public float Monedas {
		get {
			return this.monedas;
		}
		set {
			monedas = value;
		}
	}

	public HabilidadesPasivas ManejadorHabilidadesPasivas {
		get {
			return this.manejadorHabilidadesPasivas;
		}
		set {
			manejadorHabilidadesPasivas = value;
		}
	}

	public Arma ArmaActual {
		get {
			return this.armaActual;
		}
		set {
			armaActual = value;
		}
	}


}
