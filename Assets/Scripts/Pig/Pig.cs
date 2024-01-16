using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Pig : MonoBehaviour
{
    [SerializeField] private float _shotDelay;

    [SerializeField] private Transform _shootingPoint;

    private Transform _transform;
    private Coroutine _shotting;
    private BulletsPool _bulletsPool;

    public event UnityAction Killed;

    public void Initialize(BulletsPool bulletsPool)
    {
        _transform = transform;
        _bulletsPool = bulletsPool;
    }

    private void OnEnable()
    {
        _shotting = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shotting);
    }

    public void StopShoot()
    {
        if (_shotting != null)
        {
            StopCoroutine(_shotting);
        }
    }

    public void Die()
    {
        Killed?.Invoke();
        gameObject.SetActive(false);
    }

    private IEnumerator Shoot()
    {
        Vector2 direction = (_shootingPoint.position - _transform.position).normalized;

        Bullet bullet;
        WaitForSecondsRealtime delayTime = new WaitForSecondsRealtime(_shotDelay);

        while (isActiveAndEnabled)
        {
            bullet = _bulletsPool.TryGetDisabledBullet();

            bullet.transform.position = _shootingPoint.position;
            bullet.SetDirection(direction);
            bullet.gameObject.SetActive(true);

            yield return delayTime;
        }
    }
}
