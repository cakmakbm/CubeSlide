using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
   [SerializeField] private float rotationAngle;
   private bool isTriggered=false;
   private PlayerMovement playerMovement;
   private Collider myCollider;

   private void Start()
   {
      playerMovement = FindAnyObjectByType<PlayerMovement>();
      myCollider = GetComponent<Collider>();
   }


   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {


         myCollider.enabled = false;
         Debug.Log("çarpmak");
         playerMovement.StartTurn(playerMovement.GetRotationAngle() + rotationAngle);
      }

      /* if (other.CompareTag("Player"))
      {
         isTriggered=true;


         if (playerMovement!=null)
         {
            playerMovement.StartTurn(rotationAngle);
            Debug.Log("why");

         }*/ 

        

      }
      
      
   }

