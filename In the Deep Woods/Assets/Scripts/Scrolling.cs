using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public float Speed = 1;
	public GameObject Left;
	public GameObject Right;
	public GameObject Player;
	float x = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x += Speed * Time.deltaTime;
		Left.transform.position = new Vector2(-x%32,0);
		Right.transform.position = new Vector2(-x%32+32,0);
	}
}
