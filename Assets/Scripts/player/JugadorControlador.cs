using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorControlador : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rb;
	private JugadorEstadisticas jugadorEstadisticas; //COMPOSICION
	private JugadorEstado jugadorEstado;
	private Vector2 axis; //si es horizontal o vertical actualmente
	private Vector2 last_move; //para la direccion del movimiento
	private Vector3 posicion_inicial =  new Vector3 (12.05f, -5.71f, 0f);
	SpriteRenderer sprite_renderer; 
	//Comprobadores de estado
	private string estado_actual;
	private static bool player_exist;
	private bool can_move;
	private bool is_alive = true;
	//Particulas y efectos especiales
	public GameObject particle_prefab_blood;
	public GameObject prefab_danio_flotante;
	SoundManager sfx;

	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		sprite_renderer = GetComponent<SpriteRenderer> ();
		jugadorEstadisticas = gameObject.AddComponent <JugadorEstadisticas>();
		jugadorEstado = gameObject.AddComponent <JugadorEstado>();
		sfx = FindObjectOfType<SoundManager> ();



		this.last_move.y = -1;
		jugadorEstadisticas.iniciarEstadisticas(this); //vida y velocidad movimiento
		jugadorEstado.iniciarEstado (JugadorEstado.QUIETO,this);


		if (!JugadorControlador.player_exist) {
			JugadorControlador.player_exist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void regenerarEstadisticasTotalmente(){
		jugadorEstadisticas.Vida_actual = jugadorEstadisticas.Vida_base[jugadorEstadisticas.Nivel_actual];
	}

	void applyDamage(float damage){
		
		if (jugadorEstado.Estado_actual != JugadorEstado.HERIDO) {
			if (jugadorEstadisticas.Vida_actual - damage >= 0) {
				jugadorEstadisticas.Vida_actual -= damage;

			}
			else
				jugadorEstadisticas.Vida_actual = 0;


			jugadorEstado.Estado_actual = JugadorEstado.HERIDO;
			sfx.SOUND_JUGADOR_HERIDO.Play ();
			sprite_renderer.color = new Color(sprite_renderer.color.r,sprite_renderer.color.g,sprite_renderer.color.b,0.5f);

			Instantiate (particle_prefab_blood, transform.position, transform.rotation);
			var clone = (GameObject)Instantiate (prefab_danio_flotante, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<NumerosFlotantes> ().numero = damage;
			clone.GetComponent<NumerosFlotantes> ().text_numero.color = Color.grey;
		}
	}

	//GETTERS SETTERS
	public JugadorEstadisticas JugadorEstadisticas {		get {			return this.jugadorEstadisticas;		}		set {			jugadorEstadisticas = value;		}	}

	public Vector2 Last_move {		get {			return this.last_move;		}		set {			last_move = value;		}	}

	public Vector2 Axis {		get {			return this.axis;		}		set {			axis = value;		}	}

	public Animator Animator {		get {			return this.animator;		}		set {			animator = value;		}	}

	public Rigidbody2D Rb {		get {			return this.rb;		}		set {			rb = value;		}	}

	public bool Can_move {		get {			return this.can_move;		}		set {			can_move = value;		}	}

	public bool Is_alive {		get {			return this.is_alive;		}		set {			is_alive = value;		}	}

	public Vector3 Posicion_inicial {		get {			return this.posicion_inicial;		}		set {			posicion_inicial = value;		}	}

	public SpriteRenderer Sprite_renderer {		get {			return this.sprite_renderer;		}		set {			sprite_renderer = value;		}	}

	public JugadorEstado JugadorEstado {		get {			return this.jugadorEstado;		}		set {			jugadorEstado = value;		}	}



}
