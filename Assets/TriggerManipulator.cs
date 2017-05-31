using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManipulator : MonoBehaviour {


	private GameObject m_trigger;
	private GameObject m_target;
	[SerializeField] Folding m_folding;
	private float m_moveVal;
	
	
	void Awake() {
		
	}
	
	// Use this for initialization
	void Start () {
		m_trigger = GameObject.FindWithTag("Trigger");
		m_target= GameObject.FindWithTag("Target");
		m_folding = m_trigger.GetComponent<Folding>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckStatus();
	}

	private void CheckStatus() {
		if(m_folding.m_targeting == true) {
			m_moveVal = m_folding.m_beamForce;
			MoveWall(m_moveVal,m_target);
		}
	}

	private void MoveWall(float movementDir, GameObject target){
		target.transform.Translate(Vector3.forward * Time.deltaTime * movementDir, Space.World);
	}
}
