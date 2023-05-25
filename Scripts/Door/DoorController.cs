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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            _animator.SetTrigger("OpenDoor");
            _openDoor.gameObject.SetActive(true);
            _isActive = true;
            Debug.Log("Triggered");
        }
    }

    private void OnTriggerExit(Collider other)
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _index);
        }
    }
}
