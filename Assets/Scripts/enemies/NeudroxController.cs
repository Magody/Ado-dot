﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeudroxController : EnemyController {

	public float time_pause_move;
	private float time_pause_move_counter;
	public float time_moving;
	private float time_moving_counter;
	string jugador;
	// Use this for initialization
	void Start () {
		SuperStart ();
		time_pause_move_counter = Random.Range(time_pause_move*0.75f,time_pause_move*1.25f);
		time_moving_counter = Random.Range(time_moving*0.75f,time_moving*1.25f);
		jugador = GameObject.FindGameObjectWithTag ("Player").name;
	}

	// Update is called once per frame
	void Update () {
		SuperUpdate ();
		if (is_moving) {

			time_moving_counter -= Time.deltaTime;

			if (time_moving_counter < 0f) {
				is_moving = false;
				rb.velocity = Vector2.zero;
				time_pause_move_counter = Random.Range(time_pause_move*0.75f,time_pause_move*1.25f);

			}


		} else {

			time_pause_move_counter -= Time.deltaTime;

			if (time_pause_move_counter < 0f) {
				is_moving = true;
				move_direction = new Vector3 (Random.Range (-1, 2) * move_speed, Random.Range (-1, 2) * move_speed, 0f);
				rb.velocity = move_direction;
				time_moving_counter = Random.Range(time_moving*0.75f,time_moving*1.25f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == jugador) {

			col.gameObject.SendMessageUpwards ("applyDamage", 30);

		} 
	}
}