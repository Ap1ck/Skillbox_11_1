using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Transform _character;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        _xRotation = Mathf.Clamp(_xRotation,0, 0);
    }

    private void Update()
    {
        Tracking();
    }

    private void Tracking()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _character.Rotate(Vector3.up * mouseX);
    }
}