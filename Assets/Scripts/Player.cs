using UnityEngine;

namespace Basso.Actors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Vector2 _force;
        private float _rotationAngle;
        private bool _isGrounded;

        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _rotationSpeed;

        private void Reset()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
            _force = new Vector2(0, _jumpForce);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidBody.AddForce(_force, ForceMode2D.Impulse);
            }

            if (!_isGrounded && Input.GetKey(KeyCode.Space))
            {
                _rotationAngle += Time.deltaTime * _rotationSpeed;
                _rigidBody.SetRotation(_rotationAngle);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isGrounded = true;
            _rotationAngle = 0;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _isGrounded = false;
        }
    } 
}
