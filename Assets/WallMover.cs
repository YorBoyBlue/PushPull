using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {
	public int m_direction;
	public int m_moveForce;
	public bool m_triggerActive;
	public GameObject m_trigger;
	public GameObject m_target;
	public List<GameObject> m_targetPieces;
	public int m_range;
	public float m_yPos;
	public bool m_canMove;
	
	// Use this for initialization
	void Start () {
		// things player needs to access
		m_triggerActive = false;
		m_moveForce = 1;
		m_range = 4;
		m_canMove = true;
		
		m_targetPieces = new List<GameObject>();
		
		foreach (Transform child in transform)
        {
			foreach (Transform secondChild in child)
        	{
        		m_targetPieces.Add(secondChild.gameObject);
        	}
		}
		SetDirection();
		m_yPos = m_target.transform.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveWall(m_moveForce);
	}
	void MoveWall(int force){
		if(m_canMove){
			if(m_triggerActive) {
				m_target.transform.Translate(force *(Vector3.forward * Time.deltaTime));
				CheckPosition();
				if(m_target.transform.position.y >= (m_yPos + m_range)) {
					m_canMove = false;
				}
			}
		}
	}

	void CheckPosition() {
		
		for(int i = 0; i < m_targetPieces.Count; i++){
			if(m_targetPieces[i].transform.position.y > (m_yPos + 1.0f)){
				m_targetPieces[i].SetActive(true);
			}
			if(m_targetPieces[i].transform.position.y < m_yPos) {
				m_targetPieces[i].SetActive(false);
			}
		}
		
	}

	void SetDirection() {
		m_target.transform.Rotate(m_direction * 90, 0, 0); 
	}
	
}
