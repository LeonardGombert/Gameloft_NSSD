using System;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The number of bulets to fire per second.")] private float _rateOfFire;
    [SerializeField] private Transform _turretVisuals;
    private float _timePassed;
    private GameObject _currBullet;

    private GenericPool<BulletBehaviour> _bulletPool;

    public void Config(GenericPool<BulletBehaviour> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Start()
    {
        _rateOfFire = 1 / _rateOfFire; // converts from "number of bullets per second" (more intuitive) to "time between each shot" (less intuitive)
    }

    public void UpgradeFiringRate()
    {
        _rateOfFire *= .5f;
    }

    private void Update()
    {
        TickCooldown();
    }

    private void TickCooldown()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed >= _rateOfFire)
        {
            _timePassed = 0.0f;
            FireTurrets();
        }
    }

    private void FireTurrets()
    {
        _currBullet = _bulletPool.GetFreeObject().gameObject;

        _currBullet.transform.position = _turretVisuals.position;
        _currBullet.transform.up = _turretVisuals.up;
    }
}
