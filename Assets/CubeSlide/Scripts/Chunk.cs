using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Chunk : MonoBehaviour {
   [SerializeField] private Vector3 chunkSize;
   public enum ChunkType { Duz, SagaDonus, SolaDonus }
   [SerializeField] public ChunkType type;

   // Her chunk prefab'ının ucunda bir "BitisNoktasi" objesi olmalı
   [SerializeField] public Transform BitisNoktasi; 
   



   

  
   

   private void OnDrawGizmos() {
      
      Gizmos.color = Color.blue;
      Gizmos.DrawWireCube(transform.position,chunkSize);

   }

 
}
