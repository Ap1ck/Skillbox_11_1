using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Image _openDoor;

    private bool _isActive;
    private Animator _animator;
    private int _index = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _animator.SetTrigger("OpenDoor");

        _openDoor.gameObject.SetActive(true);
        _isActive = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _openDoor.gameObject.SetActive(false);
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive)
        {
            StartNextScene();
        }
    }

    private void StartNextScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _index);
        }
    }
}
