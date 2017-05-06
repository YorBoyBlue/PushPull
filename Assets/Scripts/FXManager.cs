using UnityEngine;

public class FXManager : MonoBehaviour {

	[SerializeField] ParticleSystem m_gravityBeam;
	[SerializeField] AudioSource m_gravityBeamSound;
	[SerializeField] GameObject m_hitPrefab;

	ParticleSystem m_hitFX;

	public void Init() {
		m_hitFX = Instantiate(m_hitPrefab).GetComponent<ParticleSystem>();
	}
	
	public void PlayFX() {
		m_gravityBeam.Stop(true);
		m_gravityBeam.Play(true);
		// m_gravityBeamSound.Stop();
		// m_gravityBeamSound.Play();
	}

	public void PlayHitFX(Vector3 hitPosition) {
		m_hitFX.transform.position = hitPosition;
		m_hitFX.Stop();
		m_hitFX.Play();
	}
}

