using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    private Quaternion _targetRotation;
    private float _smooth = 1f;

    void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _targetRotation = transform.rotation;
    }

    void Update()
    {
        Movement();
        RotationCamera();       
    }

    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _agent.destination = hit.point;
            }
        }             
    }

    private void RotationCamera()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, 10 * _smooth * Time.deltaTime);
    }
}
