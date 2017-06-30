using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	[SerializeField] GameObject m_player;
	bool m_levelBeaten;
	[SerializeField] GameObject[] m_levelPrefabs;
	[SerializeField] Transform m_levelPoolTransform;
	[SerializeField] Transform m_currentLevelPosition;
	GameObject m_currentLevelPrefab;

	void Start() {
		m_currentLevelPrefab = m_levelPrefabs[GameManager.GetInstance().m_currentLevel - 1];
		m_currentLevelPrefab.transform.SetParent(m_currentLevelPosition);
		m_currentLevelPrefab.transform.localPosition = new Vector3(0, 0, 0);
		m_currentLevelPrefab.SetActive(true);
		m_player.transform.position = m_currentLevelPrefab.GetComponent<Level>().GetStartPosition().position;
		m_player.transform.rotation = m_currentLevelPrefab.GetComponent<Level>().GetStartPosition().rotation;
	}

	public void ChangeLevel(int nextLevel) {
		m_currentLevelPrefab.transform.SetParent(m_levelPoolTransform);
		m_currentLevelPrefab.transform.localPosition = new Vector3(0, 0, 0);
		m_currentLevelPrefab.SetActive(false);
		m_currentLevelPrefab = null;
		m_currentLevelPrefab = m_levelPrefabs[nextLevel - 1];
		m_currentLevelPrefab.transform.SetParent(m_currentLevelPosition);
		m_currentLevelPrefab.transform.localPosition = new Vector3(0, 0, 0);
		m_currentLevelPrefab.SetActive(true);
		m_player.transform.position = m_currentLevelPrefab.GetComponent<Level>().GetStartPosition().position;
		m_player.transform.rotation = m_currentLevelPrefab.GetComponent<Level>().GetStartPosition().rotation;
	}









	

	void MakeWall(Vector3 startPos, int xSize, int ySize, int dir, bool isVert, int range ){
		for(int i = 0; i < xSize; i++) {
			for(int j = 0; j < ySize; j++) {
				MakeWallPiece();
			}
		}
	}

	void MakeWallPiece() {
		
	}
}
