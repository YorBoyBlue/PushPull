using UnityEngine;
using System.Collections;

public class MultiShooter : MonoBehaviour {

	public GameObject Shot1;
	public GameObject Shot2;
    public GameObject Wave;
	public float Disturbance = 0;

	public int ShotType = 0;

	private GameObject NowShot;
	GameObject Bullet;
	[SerializeField] PlayerManager m_playerMan;

	bool m_inputAllowed = true;

	void Start () {
		BeamParam bp = GetComponent<BeamParam>();
		bp.BeamColor.r = 1.1f;
		bp.BeamColor.g = 0.1f;
		bp.BeamColor.b = 0.1f;
		
		NowShot = null;
		m_playerMan = transform.parent.GetComponentInParent<PlayerManager>();
	}

	void Update () {
		m_inputAllowed = m_playerMan.m_inputAllowed;
		if(m_inputAllowed) {
			if (Input.GetButtonDown("Fire1"))
			{
				GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, this.transform.rotation);
				wav.transform.Rotate(Vector3.left, 90.0f);
				wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;

				Bullet = Shot2;
				//Fire
				NowShot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
			}
				//it's Not "GetButtonDown"
			if (Input.GetButton("Fire1"))
			{
				BeamParam bp = this.GetComponent<BeamParam>();
				if(NowShot.GetComponent<BeamParam>().bGero)
					NowShot.transform.parent = transform;

				Vector3 s = new Vector3(bp.Scale,bp.Scale,bp.Scale);

				NowShot.transform.localScale = s;
				NowShot.GetComponent<BeamParam>().SetBeamParam(bp);
			}
			if (Input.GetButtonUp ("Fire1"))
			{
				if(NowShot != null)
				{
					NowShot.GetComponent<BeamParam>().bEnd = true;
				}
			}

			//create GeroBeam
			if (Input.GetButtonDown("Fire2"))
			{
				GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, this.transform.rotation);
				wav.transform.Rotate(Vector3.left, 90.0f);
				wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;

				Bullet = Shot2;
				//Fire
				NowShot = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);
			}
				//it's Not "GetButtonDown"
			if (Input.GetButton("Fire2"))
			{
				BeamParam bp = this.GetComponent<BeamParam>();
				if(NowShot.GetComponent<BeamParam>().bGero)
					NowShot.transform.parent = transform;

				Vector3 s = new Vector3(bp.Scale,bp.Scale,bp.Scale);

				NowShot.transform.localScale = s;
				NowShot.GetComponent<BeamParam>().SetBeamParam(bp);
			}
			if (Input.GetButtonUp ("Fire2"))
			{
				if(NowShot != null)
				{
					NowShot.GetComponent<BeamParam>().bEnd = true;
				}
			}
		} else {
			if(NowShot != null)
			{
				NowShot.GetComponent<BeamParam>().bEnd = true;
			}
		}
	}
}
