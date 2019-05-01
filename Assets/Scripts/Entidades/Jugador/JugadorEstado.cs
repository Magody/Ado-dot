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

	private Jugador jugador;
	private bool esta_atacando;
	private bool esta_animando;
	//temporizadores
	private float tiempo_muerte = 3f;
	private float tiempo_muerte_contador = 3f;
	public float tiempo_ataque = 0.4f;
	public float tiempo_ataque_contador = 0.4f;
	private float tiempo_herido = 1f;
	private float tiempo_herido_contador = 1f;





	public void iniciarEstado(int estado,Jugador jugador){
		estado_actual = estado;
		this.jugador = jugador;
	}

	void Update () {




		switch (estado_actual) {
		case 0:
			esta_atacando = false;
			controlesMovimientoEstandar ();
			controlesAccion ();
			break;
		case 1:
			esta_atacando = false;
			controlesMovimientoEstandar ();
			controlesAccion ();
			break;
		case 2:
			controlesMovimientoAtaque ();
			if (jugador.Tiene_arma) {
				animacionAtaqueEspada ();
			} else {
				animacionGolpe ();
			}
			break;
		case 3:
			esta_atacando = false;
			jugador.Esta_vivo = false;
			jugador.Puede_moverse = false;
			jugador.Rb.velocity = Vector2.zero;
			animacionMuerte ();
			break;
		case 4:
			controlesMovimientoHerido ();
			controlesAccionHerido ();
			animacionHerido ();
			break;
		}

		if (jugador.JugadorEstadisticas.Vida_actual <= 0) {
			this.Estado_actual = JugadorEstado.MUERTO;
		}

		animatorSetInfo ();
	}



	void controlesMovimientoEstandar(){
		
		jugador.Axis = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		bool primer_condicional_activado = false;

		if (jugador.Axis.x > 0.5f || jugador.Axis.x < -0.5f) {
			primer_condicional_activado = true;

			this.Estado_actual = JugadorEstado.MOVIENDOSE;
			//transform.Translate (new Vector3 (axis.x*velocidad_movimiento*Time.deltaTime,0,0));
			jugador.Rb.velocity = new Vector2 (jugador.Axis.x * jugador.JugadorEstadisticas.Velocidad_movimiento_actual, jugador.Rb.velocity.y);
			jugador.AxisUltimo = new Vector2 (jugador.Axis.x, 0);
		} else {
			this.Estado_actual = JugadorEstado.QUIETO;
			jugador.Rb.velocity = new Vector2 (0, jugador.Rb.velocity.y);
		}

		if (jugador.Axis.y > 0.5f || jugador.Axis.y < -0.5f) {
			
			this.Estado_actual = JugadorEstado.MOVIENDOSE;
			//transform.Translate (new Vector3 (0,axis.y*velocidad_movimiento*Time.deltaTime,0));
			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, jugador.Axis.y * jugador.JugadorEstadisticas.Velocidad_movimiento_actual);
			jugador.AxisUltimo = new Vector2 (0, jugador.Axis.y);
		} else{
			if (!primer_condicional_activado) {
				//este condicional es poque setea como falso el moviendose cuando en el condicional de arriba pudo ya haberse movido
				this.Estado_actual = JugadorEstado.QUIETO;
			}

			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, 0);
		}


		//control de lmovimiento diagonal que es más rápido de lo esperado
		if (Mathf.Abs (jugador.Axis.x) > 0.5f && Mathf.Abs (jugador.Axis.y) > 0.5f) {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual] / 2f;
		} else {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual];
		}
	}

	void controlesMovimientoHerido(){

		jugador.Axis = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		if (jugador.Axis.x > 0.5f || jugador.Axis.x < -0.5f) {
			
			//playerController.Animator.SetBool ("player_moving", true);
			jugador.Rb.velocity = new Vector2 (jugador.Axis.x * jugador.JugadorEstadisticas.Velocidad_movimiento_actual/2, jugador.Rb.velocity.y);
			jugador.AxisUltimo = new Vector2 (jugador.Axis.x, 0);
		} else {
			//playerController.Animator.SetBool ("player_moving", false);
			jugador.Rb.velocity = new Vector2 (0, jugador.Rb.velocity.y);
		}

		if (jugador.Axis.y > 0.5f || jugador.Axis.y < -0.5f) {
			//playerController.Animator.SetBool ("player_moving", true);
			//transform.Translate (new Vector3 (0,axis.y*velocidad_movimiento*Time.deltaTime,0));
			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, jugador.Axis.y * jugador.JugadorEstadisticas.Velocidad_movimiento_actual/2);
			jugador.AxisUltimo = new Vector2 (0, jugador.Axis.y);
		} else{
			//if(!primer_condicional_activado)
			//	playerController.Animator.SetBool ("player_moving", false);
			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, 0);
		}


		//control de lmovimiento diagonal que es más rápido de lo esperado
		if (Mathf.Abs (jugador.Axis.x) > 0.5f && Mathf.Abs (jugador.Axis.y) > 0.5f) {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual] / 2f;
		} else {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual];
		}
	}

	void controlesMovimientoAtaque(){

		jugador.Axis = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		if (jugador.Axis.x > 0.5f || jugador.Axis.x < -0.5f) {

			//playerController.Animator.SetBool ("player_moving", true);
			jugador.Rb.velocity = new Vector2 (jugador.Axis.x * jugador.JugadorEstadisticas.Velocidad_movimiento_actual, jugador.Rb.velocity.y);
			jugador.AxisUltimo = new Vector2 (jugador.Axis.x, 0);
		} else {
			//playerController.Animator.SetBool ("player_moving", false);
			jugador.Rb.velocity = new Vector2 (0, jugador.Rb.velocity.y);
		}

		if (jugador.Axis.y > 0.5f || jugador.Axis.y < -0.5f) {
			//playerController.Animator.SetBool ("player_moving", true);
			//transform.Translate (new Vector3 (0,axis.y*velocidad_movimiento*Time.deltaTime,0));
			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, jugador.Axis.y * jugador.JugadorEstadisticas.Velocidad_movimiento_actual);
			jugador.AxisUltimo = new Vector2 (0, jugador.Axis.y);
		} else{
			//if(!primer_condicional_activado)
			//	playerController.Animator.SetBool ("player_moving", false);
			jugador.Rb.velocity = new Vector2 (jugador.Rb.velocity.x, 0);
		}


		//control de lmovimiento diagonal que es más rápido de lo esperado
		if (Mathf.Abs (jugador.Axis.x) > 0.5f && Mathf.Abs (jugador.Axis.y) > 0.5f) {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual] / 2f;
		} else {
			jugador.JugadorEstadisticas.Velocidad_movimiento_actual = jugador.JugadorEstadisticas.Velocidad_movimiento_base[jugador.JugadorEstadisticas.Nivel_actual];
		}
	}

	void controlesAccion(){
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if (!esta_animando) {
				
				this.Estado_actual = JugadorEstado.ATACANDO;
				ataque ();
			}

		}
	}

	void controlesAccionHerido(){
		if (Input.GetKeyDown (KeyCode.A)) {
			//ataca con la espada
			if (!esta_atacando) {
				ataque ();
				if (jugador.Tiene_arma) {
					animacionAtaqueEspada ();
				} else {
					animacionGolpe ();
				}
			}
		}
	}

	void ataque(){
		esta_atacando = true;
		if (!jugador.Tiene_arma) {

			if (jugador.AxisUltimo.y > 0.5f) {
				Instantiate (ControladorGlobal.PREFAB_GOLPE, new Vector3 (transform.position.x, transform.position.y + 0.45f, transform.position.z), this.transform.rotation);
			} else if (jugador.AxisUltimo.y < -0.5f) {
				Instantiate (ControladorGlobal.PREFAB_GOLPE, new Vector3 (transform.position.x, transform.position.y - 0.44f, transform.position.z), this.transform.rotation);
			} else if (jugador.AxisUltimo.x > 0.5f) {
				Instantiate (ControladorGlobal.PREFAB_GOLPE, new Vector3 (transform.position.x + 0.6f, transform.position.y, transform.position.z), this.transform.rotation);
			} else if (jugador.AxisUltimo.x < -0.5f) {
				Instantiate (ControladorGlobal.PREFAB_GOLPE, new Vector3 (transform.position.x - 0.6f, transform.position.y, transform.position.z), this.transform.rotation);
			} 

		} 
	}

	void animatorSetInfo(){
		jugador.Animator.SetBool ("tiene_arma", jugador.Tiene_arma);
		jugador.Animator.SetFloat ("ultimo_axisX",jugador.AxisUltimo.x);
		jugador.Animator.SetFloat ("ultimo_axisY",jugador.AxisUltimo.y);
		jugador.Animator.SetInteger ("estado", estado_actual);

	}

	void animacionMuerte(){
		esta_animando = true;
		tiempo_muerte_contador -= Time.deltaTime;

		if (tiempo_muerte_contador < 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);
			tiempo_muerte_contador = tiempo_muerte;

			//cambio de estadísticas
			jugador.JugadorEstadisticas.Vida_actual = jugador.JugadorEstadisticas.Vida_base[jugador.JugadorEstadisticas.Nivel_actual];
			jugador.gameObject.transform.position = jugador.Posicion_inicial;
			jugador.Esta_vivo = true;
			jugador.Puede_moverse = true;

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

	void animacionGolpe(){
		tiempo_ataque_contador -= Time.deltaTime;
		esta_animando = true;
		if (tiempo_ataque_contador < 0) {
			tiempo_ataque_contador = tiempo_ataque;
			this.Estado_actual = JugadorEstado.QUIETO;
			esta_animando = false;
		}

	}

	void animacionHerido(){
		
		if (jugador.JugadorEstadisticas.Vida_actual > 0) {
			tiempo_herido_contador -= Time.deltaTime;
			esta_animando = true;

			if (tiempo_herido_contador < 0) {
				tiempo_herido_contador = tiempo_herido;
				jugador.SpriteRenderer.color = new Color(jugador.SpriteRenderer.color.r,jugador.SpriteRenderer.color.g,jugador.SpriteRenderer.color.b,1f);
				this.Estado_actual = JugadorEstado.QUIETO;
				esta_animando = false;
			}
		} else {
			jugador.SpriteRenderer.color = new Color (jugador.SpriteRenderer.color.r, jugador.SpriteRenderer.color.g, jugador.SpriteRenderer.color.b, 1f);
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

	public bool Esta_atacando {
		get {
			return this.esta_atacando;
		}
		set {
			esta_atacando = value;
		}
	}

}
