using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Image _openDoor;
    [SerializeField] private Image _endGame;
    [SerializeField] private ParticleSystem _confettiCannon;

    private bool _isActive;
    private Animator _animator;
    private int _index = 1;
    private int _lastIndexScene = 4;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex!=_lastIndexScene)
            {
                _animator.SetTrigger("OpenDoor");
                _openDoor.gameObject.SetActive(true);
                _isActive = true;
            }
            else if (SceneManager.GetActiveScene().buildIndex == _lastIndexScene)
            {
                _endGame.gameObject.SetActive(true);
                _confettiCannon.gameObject.SetActive(true);
                _confettiCannon.Play();
                _isActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _openDoor.gameObject.SetActive(false);
        _endGame.gameObject.SetActive(false);
        _confettiCannon.gameObject.SetActive(false);
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive)
        {
            StartNextScene();
            ExitInMenu();
        }
    }

    private void StartNextScene()
    {
        if (Input.GetKeyDown(KeyCode.E)&& SceneManager.GetActiveScene().buildIndex != _lastIndexScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _index);
        }
    }

    public void ExitInMenu()
    {
        if (Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().buildIndex == _lastIndexScene)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(0);
        }
    }
}
