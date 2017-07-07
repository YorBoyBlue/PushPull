using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	
	[SerializeField] Transform m_targetTransform;
	
	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			other.GetComponent<Rigidbody>().velocity = Vector3.zero;
			other.transform.position = m_targetTransform.position;
			other.transform.rotation = m_targetTransform.rotation;
		}
	}
}
