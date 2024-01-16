using UnityEngine;

public class BulletsPool : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }

    private void Update()
    {
        DiableObjectAbroadScreen();
    }

    public Bullet TryGetDisabledBullet()
    {
        Bullet bullet = null;

        if (TryGetObject(out GameObject result))
        {
            bullet = result.GetComponent<Bullet>();
        }
       
        return bullet;
    }
}
