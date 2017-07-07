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
	static GameManager Instance = null;
	public int m_currentLevel = 1;
	public int m_maxBeatenLevel = 1;
	int m_levels = 4;
	int[] m_levelsBeaten;

	public static GameManager GetInstance() { return Instance; }
	public int[] GetLevelsBeaten() { return m_levelsBeaten; }

	void Awake() {
		m_levelsBeaten = new int[m_levels];
		for(int i = 0; i < m_levels; i++) {
			if(PlayerPrefs.HasKey("Level" + (i + 1).ToString() + "Beaten")) {
				m_levelsBeaten[i] = PlayerPrefs.GetInt("Level" + (i + 1).ToString() + "Beaten");
			} else {
				m_levelsBeaten[i] = 0;
			}
		}
		if(PlayerPrefs.HasKey("maxBeatenLevel")) {
			int maxBeatenLevel = PlayerPrefs.GetInt("maxBeatenLevel");
			m_maxBeatenLevel = maxBeatenLevel;
		}
		DontDestroyOnLoad(this);		
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}

	public void SetLevel1() {
		m_currentLevel = 1;
	}

	public void SetLevel2() {
		m_currentLevel = 2;		
	}

	public void SetLevel3() {
		m_currentLevel = 3;		
	}

	public void SetLevel4() {
		m_currentLevel = 4;		
	}
}
