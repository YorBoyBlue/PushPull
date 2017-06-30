using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {	
	[SerializeField] Transform m_startPosition;

	public Transform GetStartPosition() { return m_startPosition; }
}
