using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEstado : MonoBehaviour {
	//usa una maquina de estados para definir más organizadamente

	public const int QUIETO = 0;
	public const int MOVIENDOSE = 1;
	public const int ATACANDO = 2;
	public const int MUERTO = 3;
	public const int HERIDO = 4;
	public int estado_actual;
	JugadorControlador jugadorControlador;

	//temporizadores
	private float tiempo_muerte = 3f;
	private float tiempo_muerte_contador = 3f;
	public float tiempo_ataque = 0.3f;
	public float tiempo_ataque_contador = 0.3f;
	private float tiempo_herido = 1f;
	private float tiempo_herido_contador = 1f;

	private bool esta_animando;

	SoundManager sfx;


	public void iniciarEstado(int estado,JugadorControlador jugadorControlador){
		estado_actual = estado;
		this.jugadorControlador = jugadorControlador;
		sfx = FindObjectOfType<SoundManager> ();
	}

	void Update () {




		switch (estado_actual) {
		case 0:
			controlesMovimientoEstandar ();
			controlesAccion ();
			break;
		case 1:
			controlesMovimientoEstandar ();
			controlesAccion ();

			break;
		case 2:
			animacionAtaqueEspada ();
			break;
		case 3:
			jugadorControlador.Is_alive = false;
			jugadorControlador.Can_move = false;
			jugadorControlador.Rb.velocity = Vector2.zero;
			animacionMuerte ();
			break;
		case 4:
			controlesMovimientoHerido ();
			animacionHerido ();
			break;
		}

		if (jugadorControlador.JugadorEstadisticas.Vida_actual <= 0) {
			this.Estado_actual = JugadorEstado.MUERTO;
		}

		animatorSetInfo ();
	}



	void controlesMovimientoEstandar(){
		
		jugadorControlador.Axis = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		bool primer_condicional_activado = false;

		if (jugadorControlador.Axis.x > 0.5f || jugadorControlador.Axis.x < -0.5f) {
			primer_condicional_activado = true;

			this.Estado_actual = JugadorEstado.MOVIENDOSE;
			//transform.Translate (new Vector3 (axis.x*velocidad_movimiento*Time.deltaTime,0,0));
			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Axis.x * jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual, jugadorControlador.Rb.velocity.y);
			jugadorControlador.Last_move = new Vector2 (jugadorControlador.Axis.x, 0);
		} else {
			this.Estado_actual = JugadorEstado.QUIETO;
			jugadorControlador.Rb.velocity = new Vector2 (0, jugadorControlador.Rb.velocity.y);
		}

		if (jugadorControlador.Axis.y > 0.5f || jugadorControlador.Axis.y < -0.5f) {
			
			this.Estado_actual = JugadorEstado.MOVIENDOSE;
			//transform.Translate (new Vector3 (0,axis.y*velocidad_movimiento*Time.deltaTime,0));
			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Rb.velocity.x, jugadorControlador.Axis.y * jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual);
			jugadorControlador.Last_move = new Vector2 (0, jugadorControlador.Axis.y);
		} else{
			if (!primer_condicional_activado) {
				//este condicional es poque setea como falso el moviendose cuando en el condicional de arriba pudo ya haberse movido
				this.Estado_actual = JugadorEstado.QUIETO;
			}

			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Rb.velocity.x, 0);
		}


		//control de lmovimiento diagonal que es más rápido de lo esperado
		if (Mathf.Abs (jugadorControlador.Axis.x) > 0.5f && Mathf.Abs (jugadorControlador.Axis.y) > 0.5f) {
			jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual = jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_base[jugadorControlador.JugadorEstadisticas.Nivel_actual] / 2f;
		} else {
			jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual = jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_base[jugadorControlador.JugadorEstadisticas.Nivel_actual];
		}
	}

	void controlesMovimientoHerido(){

		jugadorControlador.Axis = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		if (jugadorControlador.Axis.x > 0.5f || jugadorControlador.Axis.x < -0.5f) {
			
			//playerController.Animator.SetBool ("player_moving", true);
			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Axis.x * jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual/2, jugadorControlador.Rb.velocity.y);
			jugadorControlador.Last_move = new Vector2 (jugadorControlador.Axis.x, 0);
		} else {
			//playerController.Animator.SetBool ("player_moving", false);
			jugadorControlador.Rb.velocity = new Vector2 (0, jugadorControlador.Rb.velocity.y);
		}

		if (jugadorControlador.Axis.y > 0.5f || jugadorControlador.Axis.y < -0.5f) {
			//playerController.Animator.SetBool ("player_moving", true);
			//transform.Translate (new Vector3 (0,axis.y*velocidad_movimiento*Time.deltaTime,0));
			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Rb.velocity.x, jugadorControlador.Axis.y * jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual/2);
			jugadorControlador.Last_move = new Vector2 (0, jugadorControlador.Axis.y);
		} else{
			//if(!primer_condicional_activado)
			//	playerController.Animator.SetBool ("player_moving", false);
			jugadorControlador.Rb.velocity = new Vector2 (jugadorControlador.Rb.velocity.x, 0);
		}


		//control de lmovimiento diagonal que es más rápido de lo esperado
		if (Mathf.Abs (jugadorControlador.Axis.x) > 0.5f && Mathf.Abs (jugadorControlador.Axis.y) > 0.5f) {
			jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual = jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_base[jugadorControlador.JugadorEstadisticas.Nivel_actual] / 2f;
		} else {
			jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_actual = jugadorControlador.JugadorEstadisticas.Velocidad_movimiento_base[jugadorControlador.JugadorEstadisticas.Nivel_actual];
		}
	}

	void controlesAccion(){
		if (Input.GetKeyDown (KeyCode.A)) {
			//ataca con la espada
			if (!esta_animando)
				this.Estado_actual = JugadorEstado.ATACANDO;
			else {
				animacionAtaqueEspada ();

			}
			sfx.SOUND_JUGADOR_ATAQUE.Play ();
		}
	}

	void animatorSetInfo(){
		
		jugadorControlador.Animator.SetFloat ("ultimo_axisX",jugadorControlador.Last_move.x);
		jugadorControlador.Animator.SetFloat ("ultimo_axisY",jugadorControlador.Last_move.y);
		jugadorControlador.Animator.SetInteger ("estado", estado_actual);
	}

	void animacionMuerte(){
		esta_animando = true;
		tiempo_muerte_contador -= Time.deltaTime;

		if (tiempo_muerte_contador < 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);
			tiempo_muerte_contador = tiempo_muerte;

			//cambio de estadísticas
			jugadorControlador.regenerarEstadisticasTotalmente ();
			jugadorControlador.gameObject.transform.position = jugadorControlador.Posicion_inicial;
			jugadorControlador.Is_alive = true;
			jugadorControlador.Can_move = true;

			this.estado_actual = JugadorEstado.QUIETO;
			esta_animando = false;
		}
	}

	void animacionAtaqueEspada(){
		tiempo_ataque_contador -= Time.deltaTime;
		esta_animando = true;
		if (tiempo_ataque_contador < 0) {
			tiempo_ataque_contador = tiempo_ataque;
			this.Estado_actual = JugadorEstado.QUIETO;
			esta_animando = false;
		}
	}

	void animacionHerido(){
		
		if (jugadorControlador.JugadorEstadisticas.Vida_actual > 0) {
			tiempo_herido_contador -= Time.deltaTime;
			esta_animando = true;

			if (tiempo_herido_contador < 0) {
				tiempo_herido_contador = tiempo_herido;
				jugadorControlador.Sprite_renderer.color = new Color(jugadorControlador.Sprite_renderer.color.r,jugadorControlador.Sprite_renderer.color.g,jugadorControlador.Sprite_renderer.color.b,1f);
				this.Estado_actual = JugadorEstado.QUIETO;
				esta_animando = false;
			}
		} else {
			jugadorControlador.Sprite_renderer.color = new Color (jugadorControlador.Sprite_renderer.color.r, jugadorControlador.Sprite_renderer.color.g, jugadorControlador.Sprite_renderer.color.b, 1f);
		}
	}


	public int Estado_actual {
		get {
			return this.estado_actual;
		}
		set {
			estado_actual = value;
		}
	}

	public float Tiempo_ataque {
		get {
			return this.tiempo_ataque;
		}
		set {
			tiempo_ataque = value;
		}
	}

	public float Tiempo_ataque_contador {
		get {
			return this.tiempo_ataque_contador;
		}
		set {
			tiempo_ataque_contador = value;
		}
	}

	public bool Esta_animando {
		get {
			return this.esta_animando;
		}
		set {
			esta_animando = value;
		}
	}

}
