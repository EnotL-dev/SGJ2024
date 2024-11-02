using UnityEngine;

namespace Guild
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;
        private Rigidbody2D _rigidbody;

        private void FixedUpdate()
        {
            Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moving = Vector3.ClampMagnitude(moving, 1);
            _animator.SetFloat("X", moving.x);
            _animator.SetFloat("Y", moving.y);
            _rigidbody.MovePosition(transform.position + _speed * Time.fixedDeltaTime * moving);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}