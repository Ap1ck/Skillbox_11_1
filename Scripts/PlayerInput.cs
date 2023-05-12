using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasLose;
        [SerializeField] private ParticleSystem _particle;

        private Animator _animations;

        private Vector3 _movement;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _animations = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVariors.Horizontal);
            float vertical = Input.GetAxis(GlobalStringVariors.Vertical);

            _movement = new Vector3(horizontal, 0, vertical).normalized;
        }


        private void FixedUpdate()
        {
            _playerMovement.MoveCharecter(_movement);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Zone_Lose")
            {
                _particle.gameObject.SetActive(true);
                _particle.Play();
                _canvasLose.SetActive(true);
                Coroutine coroutine = StartCoroutine(timer());
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
