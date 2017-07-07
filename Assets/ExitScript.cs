using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	[SerializeField] LevelManager m_levelManager;

	public int m_levelNumber;	

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag =="Player") {
			Debug.Log("Player beat the level");
			GameManager.GetInstance().m_currentLevel++;

			int[] levelsBeaten = GameManager.GetInstance().GetLevelsBeaten();
			if(levelsBeaten[m_levelNumber - 1] < 1) {
				GameManager.GetInstance().m_maxBeatenLevel++;
				PlayerPrefs.SetInt("maxBeatenLevel", GameManager.GetInstance().m_maxBeatenLevel);
				PlayerPrefs.SetInt("Level" + m_levelNumber.ToString() + "Beaten", 1);
				levelsBeaten[m_levelNumber - 1] = 1;
			}

			int nextLevel = GameManager.GetInstance().m_currentLevel;
			m_levelManager.ChangeLevel(nextLevel);
		}
	}
}
