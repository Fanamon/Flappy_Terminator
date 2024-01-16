using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void Reset()
    {
        _transform.position = Vector2.zero;
        _transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}