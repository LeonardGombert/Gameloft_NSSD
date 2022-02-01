using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _bulletPoolSize;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private ShootingBehaviour[] _turrets;

    private ObjectPool<BulletBehaviour> _bulletPool;

    void Awake()
    {
        _bulletPool = new ObjectPool<BulletBehaviour>(_bulletPoolSize, _bulletPrefab, transform);
        _bulletPool.FillPool();

        foreach (var turret in _turrets)
        {
            turret.Config(_bulletPool);
        }
    }
}
