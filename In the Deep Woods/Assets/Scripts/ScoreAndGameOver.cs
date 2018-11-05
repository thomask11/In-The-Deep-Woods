using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndGameOver : MonoBehaviour {

	public bool gameOver;
	public float score;
	public Text scoreCount;

	// Use this for initialization
	void Start () {
	
}
	// Update is called once per frame
	void Update () {
		
		if(!gameOver){
			score += Time.deltaTime * 5;
			scoreCount.text = "score: "+ Mathf.RoundToInt(score);
		}
	}

	void OnTriggerEnter2D(Collider2D obstacleHit){
        if(obstacleHit.gameObject.tag != "ObstacleTrigger" && !gameOver){
            gameOver = true;
        }
    }
}
