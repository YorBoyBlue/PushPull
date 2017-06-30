using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	[SerializeField] GameObject m_controlsScreen;
	[SerializeField] GameObject m_LevelSelectScreen;
	[SerializeField] Button[] m_levelButtons;
	[SerializeField] Sprite[] m_activeButtonImages;
	int m_maxBeatenLevel;

	void Start() {
		SetLevelButtons();
	}

	void SetLevelButtons() {
		m_maxBeatenLevel = GameManager.GetInstance().m_maxBeatenLevel;
		for(int i = 0; i < m_maxBeatenLevel; i++) {
			m_levelButtons[i].interactable = true;
			m_levelButtons[i].image.sprite = m_activeButtonImages[i];
		}
	}

	public void Play() {
		SceneManager.LoadScene("main");
	}

	public void Exit() {
		Application.Quit();
	}

	public void ShowControls() {
		m_controlsScreen.SetActive(true);
	}

	public void HideControls() {
		m_controlsScreen.SetActive(false);
	}

	public void ShowLevelSelect() {
		m_LevelSelectScreen.SetActive(true);
	}

	public void HideLevelSelect() {
		m_LevelSelectScreen.SetActive(false);
	}
}
