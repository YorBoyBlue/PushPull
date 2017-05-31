using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
     
    public Transform cube;
    public int gridWidth;
    public int gridDepth;
    public int gridHeight;
  

    //switch these private eventually
    private int presetGridWidth=25;
    private int presetGridDepth=25;
    //private int presetGridHeight=25;
    
    public Material[] materialList = new Material[2];
  
    
    private int matIndex = 0;
 
 
    //public int gridHeight=10;
     
    void Start() {
        
        CheckValues();
         
        //for (int y = 0; y < gridHeight; y=y+2) 
        //{
        for(int z = 0; z < gridDepth; z++) {
            matIndex = z % 2;
            for(int x = 0; x < gridWidth; x++) {
                Instantiate (cube, new Vector3 (x, 0, z), Quaternion.identity);
                cube.GetComponent<Renderer>().material = materialList[matIndex];
                matIndex = (matIndex == 0) ? 1 : 0;
             }
        }
 
     }

      private void CheckValues() {
        // if(gridDepth == null){
             gridDepth = presetGridDepth;
        // }
        // if(gridWidth == null){
            gridWidth = presetGridWidth;
         // }
         // if(gridHeight == null){
         //      gridHeight = presetGridHeight;
         //  }
      }

     
}