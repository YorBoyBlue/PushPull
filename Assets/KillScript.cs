using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player") {
			Debug.Log("Player Died!");
			// reset bool in game manager to restart level?
			//other.gameObject.GetComponent<GameManager>().isPlayerDead = false;
		}
	}
}
