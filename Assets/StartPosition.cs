using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
	public Transform m_startPoint;
	// Use this for initialization
	void Start () {
		m_startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
