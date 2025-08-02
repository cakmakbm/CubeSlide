using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanPosition : MonoBehaviour {
    [Header(" Elements ")] 
    [SerializeField] private Transform cubeParent;
    [SerializeField] private float cubeHeight;

    private void Update() {
        

    }


    public void SetStickmanPosition(Vector3 newPosition) {

        transform.GetChild(0).localPosition = newPosition;


    }
}
