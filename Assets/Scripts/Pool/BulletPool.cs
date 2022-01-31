using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _bulletPoolSize;
    [SerializeField] private GameObject _bulletPrefab;

    private ObjectPool<BulletBehaviour> _bulletPool;

    public ObjectPool<BulletBehaviour> Pool => _bulletPool;

    // Start is called before the first frame update
    void Awake()
    {
        _bulletPool = new ObjectPool<BulletBehaviour>(_bulletPoolSize, _bulletPrefab, transform);
        _bulletPool.FillPool();
    }
}
