using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField,Range(0,500)] private float _speed;

        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void MoveCharecter(Vector3 movement)
        {
            _rigidBody.AddForce(movement * _speed*Time.fixedDeltaTime);
        }
    }
}
