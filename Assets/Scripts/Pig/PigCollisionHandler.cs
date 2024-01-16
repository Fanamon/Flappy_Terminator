using UnityEngine;

[RequireComponent(typeof(Pig))]
public class PigCollisionHandler : MonoBehaviour
{
    private Pig _pig;

    private void Start()
    {
        _pig = GetComponent<Pig>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _pig.Die();
        }
    }
}
