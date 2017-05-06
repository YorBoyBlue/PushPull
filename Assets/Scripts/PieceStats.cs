using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceStats : MonoBehaviour {

	

	//to highlight piece for player
	public bool highlighted;
	public Rigidbody rgBod;
	private Material originalMat;
	public Material currentMat;
	private Shader diffuseShader;
	private Shader illumShader;
	public Collider coll;
	public Transform trans;
	
	
	void Awake()
	{
		highlighted 	= false;
		originalMat 	= gameObject.GetComponent<MeshRenderer>().material;
		currentMat 		= originalMat;
		currentMat.shader = Shader.Find("Diffuse");
		rgBod 			= GetComponent<Rigidbody>();
		diffuseShader   = Shader.Find("Diffuse");
		illumShader		= Shader.Find("Self-Illumin/Diffuse");
		coll			= GetComponent<Collider>();
		trans 			= GetComponent<Transform>();
	}

	// void Update() {
	// 	highlighted = false;
	// }
	
	void LateUpdate(){			
		if(highlighted == true){
			if(currentMat.shader != illumShader){
				Highlight(originalMat);
				currentMat.shader = illumShader;
			}
		} 
		if(highlighted == false){
			RevertColor(currentMat);
			if(currentMat.shader != diffuseShader){			
				currentMat.shader = diffuseShader;
			}			
		}
	}

	void Highlight(Material target){			
		target.color = Color.blue;
		highlighted = true;	
    }

	void RevertColor(Material target){
		target.color = Color.cyan;
		highlighted = false;			
	}

	Material TransparentEffect(Material target){
		Material m = target;
		m.color.a.Equals(250);
		return m;
	}
}
