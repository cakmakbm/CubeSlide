using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   [Header(" Settings ")] 
   [SerializeField] private float movementSpeed;
   [SerializeField] private float slideSpeed;
   [SerializeField] private float roadWith;

   private Vector3 clickedScreenPosition;
   private Vector3 clickedPlayerPosition;
   private void Update() {

      MoveForward();
      MoveWithInput();


   }

   private void MoveForward() {

      transform.Translate(Vector3.forward * (Time.deltaTime * movementSpeed));
   }

   private void MoveWithInput() {

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
         position.x = Mathf.Clamp(position.x, -roadWith / 2, roadWith / 2);

         transform.position = position;

      }
   }
   
   
}
