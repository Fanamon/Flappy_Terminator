using UnityEngine;

public class PigGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private BulletsPool _bulletsPool;

    [SerializeField] private Bird _bird;

    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime = 0;

    private Pig[] _pigs;

    private void Awake()
    {
        Initialize(_template);

        GetPigsPoolComponents();
        InitializePigs();
    }

    private void OnEnable()
    {
        foreach (var pig in _pigs)
        {
            pig.Killed += OnPigKilled;
        }
    }

    private void OnDisable()
    {
        foreach (var pig in _pigs)
        {
            pig.Killed -= OnPigKilled;
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pig))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pig.transform.position = spawnPoint;
                pig.SetActive(true);
            }
        }

        DiableObjectAbroadScreen();
    }

    public void StopShooting()
    {
        foreach (Pig pig in _pigs)
        {
            if (pig.gameObject.activeSelf)
            {
                pig.StopShoot();
            }
        }
    }

    private void OnPigKilled()
    {
        _bird.IncreaseScore();
    }

    private void InitializePigs()
    {
        foreach (Pig pig in _pigs)
        {
            pig.Initialize(_bulletsPool);
        }
    }

    private void GetPigsPoolComponents()
    {
        GameObject[] pigs = GetPoolObjects();
        _pigs = new Pig[pigs.Length];

        for (int i = 0; i < pigs.Length; i++)
        {
            _pigs[i] = pigs[i].GetComponent<Pig>();
        }
    }
}