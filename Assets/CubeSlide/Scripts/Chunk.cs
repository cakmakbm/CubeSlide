using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ChunkDirection
{
   ForwardZ,
   RightX,
   LeftX,
   BackwardZ
}
public class Chunk : MonoBehaviour {
   [SerializeField] private float length = 10f;
   [SerializeField] private Vector3 chunkSize;
   [SerializeField] private ChunkDirection direction = ChunkDirection.ForwardZ;
   



   public float GetLength() {
      
      return length;

   }

  
   public ChunkDirection GetDirection() => direction;

   private void OnDrawGizmos() {
      
      Gizmos.color = Color.blue;
      Gizmos.DrawWireCube(transform.position,chunkSize);

   }

 
}
