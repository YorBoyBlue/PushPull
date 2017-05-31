using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCast : MonoBehaviour {

	
	private RaycastHit hit;
    [SerializeField] GameObject m_currentHighlight;	
	public bool isTargettingMoveCube = false;
	public bool isTargettinganchorPoint = false;
	[SerializeField] Camera m_cam;
	float m_range;
	[SerializeField] PlayerManager m_playerMan;

	void Start() {
		m_range = m_playerMan.GetRange();
	}
	
	void Update () {
		Target();
	}

	void Target(){
		//Debug.DrawRay(transform.position, transform.forward * 10, Color.cyan);
		Vector3 spawnPosition = new Vector3();
        Vector3 direction = new Vector3();
        spawnPosition = m_cam.transform.position;
        direction = m_cam.transform.forward;
        Ray myRay = new Ray(spawnPosition, direction);
        Physics.Raycast(myRay, out hit, m_range);

		if(hit.collider != null) {
			if (hit.collider.tag == "PushPull"){ 				
				isTargettingMoveCube = true;
				if(isTargettingMoveCube){
					m_currentHighlight = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<PieceStats>().highlighted = true;					
				}
			} else if (hit.collider.tag == "Foldable"){			
				isTargettinganchorPoint = true;
				if(isTargettinganchorPoint){
					m_currentHighlight = hit.collider.gameObject;
					hit.collider.gameObject.GetComponent<PieceStats>().highlighted = true;					
				}
			}
				//for josh code
				else if (hit.collider.tag == "Trigger"){			
				isTargettinganchorPoint = true;
				if(isTargettinganchorPoint){
					m_currentHighlight = hit.collider.gameObject;
					hit.collider.gameObject.GetComponentInParent<TriggerStats>().m_highlighted = true;					
				}
			} else {
				isTargettingMoveCube = false;
				isTargettinganchorPoint = false;
				if(m_currentHighlight != null) {
					if(m_currentHighlight.CompareTag("Foldable")) {
						m_currentHighlight.GetComponent<Folding>().m_targeting = false;
					}
					m_currentHighlight.GetComponent<PieceStats>().highlighted = false;
					m_currentHighlight.GetComponentInParent<TriggerStats>().m_highlighted = false;
					m_currentHighlight = null;
				}
			}	
		}	
	}
}
