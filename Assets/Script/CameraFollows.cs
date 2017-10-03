﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {

	[SerializeField] GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		print (player.ToString ());
	}
	

	void LateUpdate () {
		transform.position = player.transform.position;
	}
}
