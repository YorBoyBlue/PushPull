using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject m_player;
	public GameObject m_start;
	public GameObject m_exit;
	public bool m_levelBeaten;
	// Use this for initialization
	void Start () {
		m_player = GameObject.FindGameObjectWithTag("Player");
		m_start = GameObject.FindGameObjectWithTag("Entrance");
		m_exit = GameObject.FindGameObjectWithTag("Exit");
		m_player.transform.position = m_start.GetComponent<StartPosition>().m_startPoint.position;
		m_levelBeaten = false;
	}
	
	// Update is called once per frame
	void Update () {
		
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
