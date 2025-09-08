using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [Header("Follow Settings")]
    public Transform target;
    public float smoothSpeed = 5f;

    [Header("Zoom Settings")]
    public Vector3 baseOffset;
    public Vector3 offsetPerCube;

    private CubeParent playerStack;
    private Vector3 targetOffset;

    void Start()
    {
        playerStack = FindObjectOfType<CubeParent>();
        if (playerStack == null)
        {
            Debug.LogError("PlayerStack script could not be found in the scene!");
        }
        
        targetOffset = baseOffset;
    }

    void LateUpdate()
    {
        if (target == null || playerStack == null) return;

        int cubeCount = playerStack.GetCubeCount();
        
        targetOffset = baseOffset + (offsetPerCube * cubeCount);
        
        Vector3 desiredPosition = target.position + targetOffset;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;
        
        transform.LookAt(target);
    }
}

