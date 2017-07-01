using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {
	Vector3 m_originalTargetLocalPosition;
	public int m_direction;
	public float m_moveForce;
	public bool m_triggerActive;
	public GameObject m_trigger;
	public GameObject m_target;
	public List<GameObject> m_targetPieces;
	public int m_range;
	float m_offset = 0.2f;
	public float m_yPos;
	
	// Use this for initialization
	void Start () {
		// things player needs to access
		m_originalTargetLocalPosition = m_target.transform.localPosition;
		m_range = 4;
		
		m_targetPieces = new List<GameObject>();
		
		foreach (Transform child in transform)
        {
			foreach (Transform secondChild in child)
        	{
        		m_targetPieces.Add(secondChild.gameObject);
        	}
		}
		SetDirection();	
	}

	void OnEnable() {
		m_triggerActive = false;
		m_target.transform.localPosition = m_originalTargetLocalPosition;
		m_yPos = m_target.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_triggerActive){
			MoveWall(m_moveForce);
		}
		if(Input.GetButtonUp("Fire2") || Input.GetButtonUp("Fire1")) {
			m_triggerActive = false;
		}
	}
	void MoveWall(float force) {
		m_target.transform.Translate(force * (Vector3.forward * Time.deltaTime));
		CheckPosition();
		if(m_target.transform.position.y >= m_yPos + (m_range + m_offset)) {
			m_triggerActive = false;
			Vector3 pos = new Vector3(m_target.transform.position.x, m_yPos + (m_range + m_offset), m_target.transform.position.z);
			m_target.transform.position = pos;
		}	
		if(m_target.transform.position.y <= m_yPos) {
			m_triggerActive = false;
			Vector3 pos = new Vector3(m_target.transform.position.x, m_yPos, m_target.transform.position.z);
			m_target.transform.position = pos;
		}		
	}

	void CheckPosition() {		
		for(int i = 0; i < m_targetPieces.Count; i++){
			if(m_targetPieces[i].transform.position.y > (m_yPos + -0.1f)){
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
