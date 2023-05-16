using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _canvasLose;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Image _menu;

        private int _quantity=0;

        private Animator _animations;

        private Vector3 _movement;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _animations = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVariors.Horizontal);
            float vertical = Input.GetAxis(GlobalStringVariors.Vertical);
            _movement = new Vector3(horizontal, 0, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _menu.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        private void FixedUpdate()
        {
            _playerMovement.MoveCharecter(_movement);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Zone_Lose")
            {
                Cursor.lockState = CursorLockMode.Confined;
                _particle.gameObject.SetActive(true);
                _particle.Play();
                _canvasLose.SetActive(true);
                Coroutine timerPanel = StartCoroutine(timer());
            }
        }

        private void OnEnable()
        {
            StarController._coin += TakeCoin;
        }

        private void OnDisable()
        {
            StarController._coin -= TakeCoin;
        }

        private void TakeCoin(int value)
        {
            _quantity += value;
            _text.text ="Star:"+ _quantity.ToString();
        }

        private IEnumerator timer()
        {
            _animations.SetTrigger("Died");
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 0;
        }
    }
}
