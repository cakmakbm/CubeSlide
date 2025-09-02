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

   /*private void MoveWithInput() {

      if (Input.GetMouseButtonDown(0)) {

         clickedScreenPosition = Input.mousePosition;
         clickedPlayerPosition = transform.position;
         

      }

      else if (Input.GetMouseButton(0)) {

         float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
         xScreenDifference /= Screen.width;
         xScreenDifference *= slideSpeed;
         Vector3 position = transform.position;
         position.x = clickedPlayerPosition.x + xScreenDifference;
         //position.x = Mathf.Clamp(position.x, -roadWith / 2, roadWith / 2);

         transform.position = position;

      }
   }*/

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
