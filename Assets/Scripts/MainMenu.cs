using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField] GameObject m_controlsScreen;

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
}
