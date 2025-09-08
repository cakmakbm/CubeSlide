using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParent : MonoBehaviour {
    public int GetCubeCount() {
        return transform.childCount;
    }
    
}
