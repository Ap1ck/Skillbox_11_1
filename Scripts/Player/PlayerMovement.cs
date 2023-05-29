using UnityEngine;

namespace WildBall.Inputs
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speedWalk;
        [SerializeField] private float _gravity;
        [SerializeField] private float _jumpPower;

        private CharacterController _characterController;
        private Vector3 _walkDirection;
        private Vector3 _velocity;
       
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Jump(Input.GetKey(KeyCode.Space) && _characterController.isGrounded);
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            _walkDirection = transform.right * x + transform.forward * z;
        }

        private void FixedUpdate()
        {
            Walk(_walkDirection);
            DoGravity(_characterController.isGrounded);
        }

        private void Walk(Vector3 direction)
        {
            _characterController.Move(direction * _speedWalk * Time.fixedDeltaTime);
        }

        private void DoGravity(bool isGrounded)
        {
            if (isGrounded && _velocity.y < 0)
                _velocity.y = -1f;
            _velocity.y -= _gravity * Time.fixedDeltaTime;
            _characterController.Move(_velocity * Time.fixedDeltaTime);
        }

        private void Jump(bool canJump)
        {
            if (canJump)
                _velocity.y = _jumpPower;
        }
    }
}
