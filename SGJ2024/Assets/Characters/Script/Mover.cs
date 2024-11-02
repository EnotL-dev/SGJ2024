using UnityEngine;

namespace Guild
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;

        private void FixedUpdate()
        {
            Vector3 moving = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moving = Vector3.ClampMagnitude(moving, 1);
            _rigidbody.MovePosition(transform.position + moving * _speed * Time.fixedDeltaTime);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}