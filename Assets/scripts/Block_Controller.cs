﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {
	public GameObject life;
	private int block_health = 1;	

	// Use this for initialization
	void Start () {
		GM.block_count++;

		switch (gameObject.tag) {

		case "RedBrick":
			block_health = 1;
			break;

		case "YellowBrick":
			block_health = 2;
			break;




		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D (Collision2D hit){

		if (hit.gameObject.name == "Ball")
			block_health--;


	}

	void OnCollisionExit2D (Collision2D hit){

		if(block_health <=0){
			GM.block_count--;

			if (transform.childCount > 0) {
			GameObject newLife = Instantiate (life);
			newLife.transform.parent = (GameObject.Find ("Bricks")).transform;
			newLife.name = "life";
			newLife.transform.position = GameObject.Find ("RedBrick (15)").transform.position;
				newLife.AddComponent<Rigidbody2D> ();
			}

			Destroy (gameObject);

			switch (gameObject.tag) {

			case "RedBrick":
				GM.score += 5;
				break;

			case "YellowBrick":
				GM.score += 11;
				break;

			default:
				GM.score += 5;
				break;



			}
		}
	}
}
