﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, -1);
		
	}
}
