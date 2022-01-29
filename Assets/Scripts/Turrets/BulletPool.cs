using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletPool = new List<GameObject>();
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize;

    private void Start()
    {
        GameObject buff;
        for (int i = 0; i < _poolSize; i++)
        {
            buff = Instantiate(_bulletPrefab, transform);
            buff.SetActive(false);
            _bulletPool.Add(buff);
        }
    }

    public GameObject GetFreeBullet()
    {
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}