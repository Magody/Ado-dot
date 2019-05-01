using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGlobal : MonoBehaviour {



	public const string STRING_DANIO_FISICO = "fisico";
	public const string STRING_DANIO_MAGICO = "magico";
	public const string STRING_TAG_ENEMIGO = "Enemy";
	public const string STRING_TAG_MAPA = "mapa";

	public static ManejadorMusica manejadorMusica;
	public static ManejadorSFX manejadorSFX;
	public static SpriteRenderer fondo_flujo_anormal_tiempo;
	public static bool flujo_normal_tiempo = true;
	public static Jugador jugador;

	public static float PANTALLA_ANCHO = Screen.width;
	public static float PANTALLA_ALTO = Screen.height;


	//prefabs
	public static GameObject PREFAB_SANGRE_ROJA;
	public static GameObject PREFAB_SANGRE_AZUL;
	public static GameObject PREFAB_SANGRE_BLANCA;
	public static GameObject PREFAB_TEXTO_FLOTANTE;
	public static GameObject PREFAB_GOLPE;
	public static GameObject PREFAB_VAMPIRISMO;

	public static GameObject PREFAB_MONEDA;

	private static bool existe_controlador_global;

	void Awake(){

		if (!ControladorGlobal.existe_controlador_global) {
			ControladorGlobal.existe_controlador_global = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (this.gameObject);
		}

		jugador = FindObjectOfType<Jugador> ();
		ControladorGlobal.fondo_flujo_anormal_tiempo = GameObject.Find ("flujo_anormal_tiempo").GetComponent<SpriteRenderer>();

		PREFAB_SANGRE_ROJA = Resources.Load ("PrefabsCargados/Sangre/prefab_sangre_roja") as GameObject;
		PREFAB_SANGRE_AZUL = Resources.Load ("PrefabsCargados/Sangre/prefab_sangre_azul") as GameObject;
		PREFAB_SANGRE_BLANCA = Resources.Load ("PrefabsCargados/Sangre/prefab_sangre_blanca") as GameObject;
		PREFAB_TEXTO_FLOTANTE = Resources.Load ("PrefabsCargados/prefab_texto_flotante") as GameObject;
		PREFAB_GOLPE = Resources.Load ("PrefabsCargados/prefab_golpe") as GameObject;
		PREFAB_VAMPIRISMO = Resources.Load ("PrefabsCargados/Habilidades/prefab_vampirismo") as GameObject;

		PREFAB_MONEDA = Resources.Load ("PrefabsCargados/Objetos/prefab_moneda") as GameObject;

		manejadorMusica = FindObjectOfType<ManejadorMusica>();
		manejadorSFX = FindObjectOfType<ManejadorSFX>();

	}


}
