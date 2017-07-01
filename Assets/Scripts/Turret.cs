using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	
	private RaycastHit hit;
	float m_range = 30f;
	[SerializeField] Transform m_firePosition;
	[SerializeField] Transform m_turretSwivel;
	[SerializeField] GameObject m_bulletPrefab;
	[SerializeField] Transform m_playerCenterTransform;
	private GameObject m_bullet;
	private float m_bulletSpeed;
	private float m_destroyBulletDelay;
	private float m_bulletSpawnDelay;
	private float m_maxBulletSpawnDelay;
	private float m_fireBulletTime;
	private float m_maxFireBulletTime;
	private float m_dontFireBulletTime;
	private float m_maxDontFireBulletTime;
	private float m_rotationDamping;
	private Rigidbody m_rb;
	private Quaternion m_rotation;

	void Awake(){
		m_rb = m_turretSwivel.GetComponent<Rigidbody>();
		m_bulletSpeed = 2f;
		m_destroyBulletDelay = 2.0f;
		m_maxBulletSpawnDelay = 0.5f;
		m_maxFireBulletTime = 4.0f;
		m_maxDontFireBulletTime = 2.0f;
		m_rotationDamping = 2.0f;
		m_bulletSpawnDelay = m_maxBulletSpawnDelay;
		m_fireBulletTime = m_maxFireBulletTime;
		m_dontFireBulletTime = m_maxDontFireBulletTime;
	}

	void FixedUpdate(){
		TrackPlayer();
		if(IsPlayerInRange()) {
			FireBullets();
		}
	}

	bool IsPlayerInRange() {
		bool isPlayerInRange = false;

		Vector3 spawnPosition = new Vector3();
        Vector3 direction = new Vector3();
        spawnPosition = m_firePosition.transform.position;
        direction = m_firePosition.transform.forward;
        Ray myRay = new Ray(spawnPosition, direction);
        Physics.Raycast(myRay, out hit, m_range);

		if(hit.collider != null) {
			if(hit.collider.gameObject.CompareTag("Player")) {
				isPlayerInRange = true;
			}
		}
		return isPlayerInRange;
	}

	void TrackPlayer() {
		m_rotation = Quaternion.LookRotation(m_playerCenterTransform.position - m_rb.transform.position);
		m_rb.transform.rotation = Quaternion.Slerp(m_rb.transform.rotation, m_rotation, Time.deltaTime * m_rotationDamping);
	}

	private void FireBullets(){
		m_dontFireBulletTime -= Time.deltaTime;

		if(m_dontFireBulletTime <= 0){
			m_bulletSpawnDelay -= Time.deltaTime;
			m_fireBulletTime -= Time.deltaTime;
			if(m_bulletSpawnDelay <= 0){				
				m_bullet = (GameObject)Instantiate(m_bulletPrefab, m_firePosition.position, m_firePosition.rotation);
				m_bullet.GetComponent<Rigidbody>().velocity = m_firePosition.transform.forward * m_bulletSpeed;
				Destroy(m_bullet, m_destroyBulletDelay); 
				m_bulletSpawnDelay = m_maxBulletSpawnDelay;
			}
			if(m_fireBulletTime <= 0){
				m_dontFireBulletTime = m_maxDontFireBulletTime;
				m_fireBulletTime = m_maxFireBulletTime;
			}
		}
    }
}
