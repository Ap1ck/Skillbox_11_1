using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasLose;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Image _menu;

        private Animator _animations;

        private void Awake()
        {
            _animations = GetComponent<Animator>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _menu.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Zone_Lose"))
            {
                Cursor.lockState = CursorLockMode.Confined;
                _particle.gameObject.SetActive(true);
                _particle.Play();
                _canvasLose.SetActive(true);
                Coroutine timerPanel = StartCoroutine(timer());
            }
        }

        private IEnumerator timer()
        {
            _animations.SetTrigger("Died");
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 0;
        }
    }
}
