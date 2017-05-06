using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetUI : MonoBehaviour {
	
	void Start () {
		BeamParam bp = GameObject.Find("Shooter").GetComponent<BeamParam>();

		bp.BeamColor.r = 1.1f;
		bp.BeamColor.g = 0.1f;
		bp.BeamColor.b = 0.1f;
	}
}
