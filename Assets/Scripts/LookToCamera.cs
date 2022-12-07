using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private Vector3 rotationVector;  
    private Camera cameraRotation;
    private void Start()
    {
        cameraRotation = Camera.main;
    }

    void Update()
    {
        rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = cameraRotation.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
