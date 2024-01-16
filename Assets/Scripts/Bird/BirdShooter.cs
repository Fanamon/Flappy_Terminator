using Unity.VisualScripting;
using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private BulletsPool _bulletsPool;

    [SerializeField] private Transform _shootingPoint;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left) && Time.timeScale == 1)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = _bulletsPool.TryGetDisabledBullet();
        Vector2 direction = (_shootingPoint.position - _transform.position).normalized;

        bullet.transform.position = _shootingPoint.position;
        bullet.SetDirection(direction);
        bullet.transform.rotation = new Quaternion(direction.x, direction.y, 0, 0);
        bullet.gameObject.SetActive(true);
    }
}
