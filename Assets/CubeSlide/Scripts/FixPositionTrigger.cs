using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPositionTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

           
            Vector3 newPosition = new Vector3(
                transform.position.x,           
                other.transform.position.y,     
                transform.position.z            
            );

          
            other.transform.position = newPosition;

            
            other.transform.rotation = transform.rotation;
            
           
            gameObject.SetActive(false);        }
        
    }
}
