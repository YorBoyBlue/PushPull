using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folding : MonoBehaviour {
	[SerializeField] GameObject[] m_walls;
	[SerializeField] Transform m_target;
	[SerializeField] Transform m_startTarget;
	[SerializeField] Transform m_startPosition;


	public bool m_anchorStopped = false;
	bool m_hasReachedMax = false;
	bool m_hasReachedMin = false;
	public bool m_targeting = false;
	public float m_moveAmount = 0;
	int m_maxMoveAmount;
	float m_movementPerFrame = 0.5f;
	int m_increment;
	public float m_beamForce;
	bool m_init = false;
	float m_moveLength;
	float m_startTime;
	float m_speed = 1f;

	public void SetBeamForce(float value) { m_beamForce = value; }
	
	void Start() {
		m_startPosition.position = this.transform.position;
		for(int i = 0; i < m_walls.Length; i++) {
			if(m_walls[i] != null) {
				m_maxMoveAmount++;
			}
		}
		m_target = m_walls[0].transform;
		m_startTarget = m_startPosition;
	}

	void Update() {
		MoveAnchorPoint();
		ConstructWall(m_beamForce);
	}

	void MoveAnchorPoint() {
		if(m_targeting) {
			this.transform.position = Vector3.Lerp(this.transform.position, m_target.position, m_speed * Time.deltaTime);
		}
	}

	public void ConstructWall(float beamForce) {
		if(beamForce > 0) {
			Activate();
		} else {
			Deactivate();
		}
	}	

	void Activate() {
		if(Input.GetButtonUp("Fire1")) {
				m_targeting = false;
			}
			if(m_targeting) {
				m_hasReachedMin = false;
				if(m_moveAmount < m_maxMoveAmount) {
					m_moveAmount += m_movementPerFrame * Time.deltaTime;
				} else {
					m_hasReachedMax = true;
				}
				if(!m_hasReachedMax) {
					m_increment = (int)m_moveAmount - 1;
					switch(m_increment) {
					case 0:
						if(m_walls[0] != null) {
							m_startTarget = m_startPosition;
							m_target = m_walls[0].transform;
						}
						m_walls[0].SetActive(true);						
					break;
					case 1:
						if(m_walls[1] != null) {
							m_startTarget = m_walls[0].transform;
							m_target = m_walls[1].transform;
						}
						m_walls[1].SetActive(true);
					break;
					case 2:
						if(m_walls[2] != null) {
							m_startTarget = m_walls[1].transform;
							m_target = m_walls[2].transform;
						}
						m_walls[2].SetActive(true);
					break;
					case 3:
						if(m_walls[3] != null) {
							m_startTarget = m_walls[2].transform;
							m_target = m_walls[3].transform;
						}
						m_walls[3].SetActive(true);
					break;
					case 4:
						if(m_walls[4] != null) {
							m_startTarget = m_walls[3].transform;
							m_target = m_walls[4].transform;
						}
						m_walls[4].SetActive(true);
					break;
					case 5:
						if(m_walls[5] != null) {
							m_startTarget = m_walls[4].transform;
							m_target = m_walls[5].transform;
						}
						m_walls[5].SetActive(true);
					break;
					case 6:
						if(m_walls[6] != null) {
							m_startTarget = m_walls[5].transform;
							m_target = m_walls[6].transform;
						}
						m_walls[6].SetActive(true);
					break;
				}
			}	
		}
	}

	void Deactivate() {
		if(Input.GetButtonUp("Fire2")) {
				m_targeting = false;
		}
		if(m_targeting) {
			m_hasReachedMax = false;
			if(m_moveAmount > 0) {
				m_moveAmount -= m_movementPerFrame * Time.deltaTime;
			} else {
				m_hasReachedMin = true;
			}
			if(!m_hasReachedMin) {
					m_increment = (int)m_moveAmount;
					switch(m_increment) {
					case 0:
						if(m_startPosition != null) {
							m_startTarget = m_walls[0].transform;
							m_target = m_startPosition;
						}
						m_walls[0].SetActive(false);
					break;
					case 1:
						if(m_walls[0] != null) {
							m_startTarget = m_walls[1].transform;
							m_target = m_walls[0].transform;
						}
						m_walls[1].SetActive(false);
					break;
					case 2:						
						if(m_walls[1] != null) {
							m_startTarget = m_walls[2].transform;
							m_target = m_walls[1].transform;
						}
						m_walls[2].SetActive(false);
					break;
					case 3:
						if(m_walls[2] != null) {
							m_startTarget = m_walls[3].transform;
							m_target = m_walls[2].transform;
						}
						m_walls[3].SetActive(false);
					break;
					case 4:
						if(m_walls[3] != null) {
							m_startTarget = m_walls[4].transform;
							m_target = m_walls[3].transform;
						}
						m_walls[4].SetActive(false);
					break;
					case 5:
						if(m_walls[4] != null) {
							m_startTarget = m_walls[5].transform;
							m_target = m_walls[4].transform;
						}
						m_walls[5].SetActive(false);
					break;
					case 6:
						if(m_walls[5] != null) {
							m_startTarget = m_walls[6].transform;
							m_target = m_walls[5].transform;
						}
						m_walls[6].SetActive(false);
					break;
				}
			}	
		}
	}
}
