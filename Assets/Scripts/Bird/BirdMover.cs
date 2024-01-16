using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRorationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _startPosition = transform.position;

        _rigidBody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRorationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0)
        {
            _rigidBody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _rigidBody.velocity = Vector2.zero;
    }
}