using UnityEngine;

public class BulletPool : Pool
{
    [SerializeField] private ShootingBehaviour[] _turrets;

    private GenericPool<BulletBehaviour> _bulletPool;

    void Awake()
    {
        _bulletPool = new GenericPool<BulletBehaviour>(_poolSize, _poolObjectPrefab, transform);
        _bulletPool.FillPool(this);

        foreach (var turret in _turrets)
        {
            turret.Config(_bulletPool);
        }
    }
}
