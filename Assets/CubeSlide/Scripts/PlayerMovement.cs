using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   [Header(" Settings ")] 
   [SerializeField] private float movementSpeed;
   [SerializeField] private float slideSpeed;
   [SerializeField] private float roadWith;
   [SerializeField] private float rotationSpeed;

   [SerializeField] private Transform cubeParent;
   
   private Quaternion aimRotation;
   private bool canMove;

  // private Vector3 clickedScreenPosition;
   //private Vector3 clickedPlayerPosition;

   private void Start()
   {
      GameManager.onGameStateChange += GameStateChangedCallBack;
      
   }

   private void Update() {

      if (canMove) {


         MoveForward();
         // MoveWithInput();
      }
      
      if (!GameManager.instance.IsGameState()) {
         
         return;
         
      }
      

      if (cubeParent.childCount <= 0) {
         
         GameManager.instance.SetGameState(GameManager.GameState.GameOver);
         
         
      }
      

   }

   private void OnDestroy()
   {
      GameManager.onGameStateChange -= GameStateChangedCallBack;
   }

   private void GameStateChangedCallBack(GameManager.GameState gameState)
   {
      if (gameState == GameManager.GameState.Game)
      {
         
         StartMoving();

      }
      else if (gameState == GameManager.GameState.GameOver)
      {
         StopMoving();
      }
      else if (gameState == GameManager.GameState.LevelComplete)
      {
         StopMoving();
      }
         
      
   }

   private void StartMoving()
   {
      canMove = true;
   }

   private void StopMoving()
   {
      canMove = false;  
   }


   private void MoveForward() {

      transform.Translate(Vector3.forward * (Time.deltaTime * movementSpeed));
      
      float rotxTime = rotationSpeed * Time.deltaTime; 
    
      
      transform.rotation = Quaternion.RotateTowards(transform.rotation, aimRotation, rotxTime);
      
   }

  

   public void StartTurn(float rotationAngle)
   {
      
      aimRotation= Quaternion.Euler(0,rotationAngle,0);
      
   }

   public float GetRotationAngle()
   {
      return transform.eulerAngles.y;
   }

   public Vector3 GetPosition()
   {
      return transform.position;
      
   }


}
