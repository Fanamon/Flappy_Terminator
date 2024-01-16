using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void ResetPool()
    {
        foreach (GameObject item in _pool)
        {
            item.SetActive(false);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);

            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected GameObject[] GetPoolObjects()
    {
        GameObject[] poolObjects = new GameObject[_pool.Count];

        for (int i = 0; i < poolObjects.Length; i++)
        {
            poolObjects[i] = _pool[i];
        }

        return poolObjects;
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DiableObjectAbroadScreen()
    {
        Vector3 disablePointLeft = _camera.ViewportToWorldPoint(new Vector2(-0.5f, -0.5f));
        Vector3 disablePointRight = _camera.ViewportToWorldPoint(new Vector2(6f, 6f));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePointLeft.x || item.transform.position.y < disablePointLeft.y ||
                    item.transform.position.x > disablePointRight.x || item.transform.position.y > disablePointRight.y)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
