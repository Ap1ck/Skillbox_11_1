using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _mouseSensitivity = 100f;

    private float _speed = 5;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _playerTransform.position;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;

        transform.position = _playerTransform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _playerTransform.transform.position, Time.deltaTime * _speed);

        transform.Rotate(Vector3.up * mouseX*Time.fixedDeltaTime);
    }
}
