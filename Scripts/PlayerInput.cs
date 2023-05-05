using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameObject _canvasLose;

        private Vector3 _movement;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
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
                _canvasLose.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
}
