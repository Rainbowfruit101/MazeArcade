using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 2;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidbody.velocity = GetMove();
        }

        private Vector2 GetMove() => new Vector2()
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        } * speed;
    }
}