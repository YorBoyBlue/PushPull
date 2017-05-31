using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

	//private Transform[] m_killzoneSettings;
	private Vector3 m_killzoneCenter;
	private Vector3 m_killzoneBounds;
	private BoxCollider m_collide;
	private GameObject Level;
	// Use this for initialization
	void Start () {
		Level = GameObject.FindGameObjectWithTag("Level");
		m_killzoneCenter = new Vector3(Level.gameObject.transform.position.x,Level.gameObject.transform.position.y,Level.gameObject.transform.position.z);
		m_killzoneBounds = new Vector3(10, 0, 10);
		//m_killzoneSettings = new Transform[2];
		m_collide = this.gameObject.GetComponent<BoxCollider>();
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			//temp kill function
			Debug.Log("Kill the player!!!!");

		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	void SetKillzoneSize() {
		m_collide.center = m_killzoneCenter;
		m_collide.size = m_killzoneBounds;
	}
}
