﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(1,0));
	}
}
