using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSystem : MonoBehaviour {
    [SerializeField] private Transform cubeParentTransform;

    private void Update() {

        /*if (!GameManager.instance.IsGameState())
        {
            return;
        }

        if (GetCubeCount()<=0)
        {
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
        }*/
        
    }
    

    private int GetCubeCount()
    {
        return cubeParentTransform.childCount;
    }

    

   
    
    
}
