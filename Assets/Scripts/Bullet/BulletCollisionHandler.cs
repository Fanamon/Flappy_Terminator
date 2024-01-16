using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class BulletCollisionHandler : MonoBehaviour
{
    private Bullet _bullet;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet) == false)
        {
            gameObject.SetActive(false);
            _bullet.Reset();
        }
    }
}
