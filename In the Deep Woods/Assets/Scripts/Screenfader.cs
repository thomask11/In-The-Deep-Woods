using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screenfader : MonoBehaviour {

public float speed;

public float time;

public float sceneTime;

public float distance;

private float startPositionx;

bool reachedDestination;

public bool switchScene;

	// Use this for initialization
	void Start () {
		startPositionx = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		
		if(!reachedDestination){
		time -= Time.deltaTime;
		if(time <= 0){
			gameObject.transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
			if(startPositionx - transform.position.x >= distance){
				gameObject.transform.position = new Vector2(startPositionx - distance, transform.position.y);
				reachedDestination = true;
				if(switchScene){
					SceneManager.LoadScene("Level");
				}
			}
		}
		}
	}
}
