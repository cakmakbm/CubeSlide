using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    [SerializeField] private float slideSpeed;
    [SerializeField] private float roadWidth;

    private Vector3 clickStartScreen;
    private Vector3 clickStartLocal;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            clickStartScreen = Input.mousePosition;
            clickStartLocal  = transform.localPosition;
        }
        else if (Input.GetMouseButton(0)) {
            float deltaX = (Input.mousePosition.x - clickStartScreen.x)
                / Screen.width * slideSpeed;
            Vector3 loc = clickStartLocal;
            loc.x = Mathf.Clamp(loc.x + deltaX,
                -roadWidth / 2f, roadWidth / 2f);
            transform.localPosition = loc;
        }
    }
}
