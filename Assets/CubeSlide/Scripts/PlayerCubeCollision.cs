using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeCollision : MonoBehaviour {
  [SerializeField] private GameObject boxPrefab;
  private CubeParent cubeParent;
  private StickmanPosition stickmanPosition;
  private Transform cubeParentTransform;
  [SerializeField] private float cubeHeight;
  
  

  private bool hasCollided = false;


  private void Start() {

   cubeParent = FindAnyObjectByType<CubeParent>();
   stickmanPosition = FindAnyObjectByType<StickmanPosition>();
   cubeParentTransform = cubeParent.transform;

  }

  private void OnCollisionEnter(Collision collision) {
    if (!hasCollided && collision.gameObject.CompareTag("ObstacleCube")) {

      hasCollided = true;
      
      transform.SetParent(null);
      collision.gameObject.tag = "Untagged";
    }

    if (collision.gameObject.CompareTag("Collect")) {
    
      
      
      Destroy(collision.gameObject);

      
      int currentStackCount = cubeParentTransform.childCount;
    
      
      float newYPosition = currentStackCount * cubeHeight;
      float newStickmanY = (currentStackCount + 1) * cubeHeight;
     

      
      Vector3 newLocalPosition = new Vector3(0, newYPosition, 0);
      Vector3 newLocalStickmanPosition = new Vector3(0, newStickmanY, 0);
      
      

    
    
     
      GameObject newCube = Instantiate(boxPrefab, cubeParentTransform); 
      stickmanPosition.SetStickmanPosition(newLocalStickmanPosition);
      newCube.transform.localPosition = newLocalPosition;

      



    }

  }

  private void OnTriggerEnter(Collider collider) {

    if (collider.gameObject.CompareTag("Pool")) {
      
      transform.SetParent(null);
      Destroy(gameObject);
      
    }
    
    
  }
}




