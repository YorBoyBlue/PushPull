using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStats : MonoBehaviour {
		

	//trigger params
	private string m_trigger = "Trigger";
	private Vector3 m_triggerScale;
	public Vector3 m_triggerLoc;
	public GameObject m_triggerCube;

	//trigger target params
	private string m_target = "Target";
	public List<GameObject> m_movingWall;
	
	public int m_wallSizeX;
	public int m_wallSizeY;
	public bool m_isWallVert = false;
	public string m_wallOrientation;
	private Transform m_wallRotation;	

	// rotation vectors
	private Vector3[] m_directions;
	


	//to highlight piece for player
	public bool m_highlighted;
	public Rigidbody m_rgBod;
	private Material m_originalMat;
	public Material m_currentMat;
	private Shader m_diffuseShader;
	private Shader m_illumShader;
	public BoxCollider m_boxColl;
	public Transform m_trans;
	
	
	void Awake()
	{	
		// init trigger data
		m_triggerScale						= new Vector3(0.5f, 0.5f, 0.5f);
		m_triggerLoc 						= new Vector3(5, 5, 5);
		m_triggerCube						= GameObject.CreatePrimitive(PrimitiveType.Cube);
        m_triggerCube.transform.position 	= m_triggerLoc;
		m_triggerCube.transform.localScale 	= m_triggerScale;
		m_triggerCube.tag					= m_trigger;

		// init target data




		// init vector data
		// for(int i = 0; i < m_directions.Length; i++) {
		// 	m_directions[i] = new Vector3()
		// }

		//un sectioned info
		m_highlighted 						= false;
		m_originalMat 						= m_triggerCube.gameObject.GetComponent<MeshRenderer>().material;
		m_currentMat 						= m_originalMat;
		m_currentMat.shader 				= Shader.Find("Diffuse");
		m_rgBod 							= m_triggerCube.AddComponent<Rigidbody>();	
		m_rgBod.isKinematic					= true;						
		m_diffuseShader   					= Shader.Find("Diffuse");
		m_illumShader						= Shader.Find("Self-Illumin/Diffuse");
		m_boxColl							= m_triggerCube.GetComponent<BoxCollider>();
		
		m_trans 							= GetComponent<Transform>();
	}

	void Start() {
		m_triggerCube.transform.parent = this.transform;
		m_wallSizeX = 2;
		m_wallSizeY = 2;
	}

	// void Update() {
	// 	highlighted = false;
	// }
	
	void LateUpdate(){			
		if(m_highlighted == true){
			if(m_currentMat.shader != m_illumShader){
				Highlight(m_originalMat);
				m_currentMat.shader = m_illumShader;
			}
		} 
		if(m_highlighted == false){
			RevertColor(m_currentMat);
			if(m_currentMat.shader != m_diffuseShader){			
				m_currentMat.shader = m_diffuseShader;
			}			
		}
	}

	void Highlight(Material target){			
		target.color = Color.blue;
		m_highlighted = true;	
    }

	void RevertColor(Material target){
		target.color = Color.cyan;
		m_highlighted = false;			
	}

	Material TransparentEffect(Material target){
		Material m = target;
		m.color.a.Equals(250);
		return m;
	}

	void CreateWall(){
		
		for(int i =0; i < m_wallSizeY; i++){
			for(int j = 0; j < m_wallSizeX; j++) {
				GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
				m_movingWall.Add(tmp);

				tmp.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + i, this.transform.position.z + j);
				
			}
		}
	}

	// void CheckOrientation() {
	// 	if(m_isWallVert){
	// 	switch(m_wallOrientation){

	// 		// cases are arbitrary currently with varying settings ****** MUST TWEAK********
	// 		case "North":
	// 			m_wallRotation.rotation = 0;
	// 			break;

	// 		case "South":
	// 			m_wallRotation = 90.0f;
	// 			break;

	// 		case "East":
	// 			m_wallRotation = 180.0f;
	// 			break;

	// 		case "West":
	// 			m_wallRotation = 270.0f;
	// 			break;
	// 	}else {
	// 		switch(m_wallOrientation){

	// 		}
	// 	}
	// 	}
	// }
}
