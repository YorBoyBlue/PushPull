using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	void OnCollisionEnter(Collision other) {
		if(other.collider.CompareTag("Player")) {
			other.collider.gameObject.GetComponent<PlayerManager>().GetLevelManager().PlayerDied(GameManager.GetInstance().m_currentLevel);
		}
	}
}
