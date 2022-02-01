using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The number of bulets to fire per second.")] private float _rateOfFire;
    private float _timePassed;
    private GameObject _currBullet;

    private ObjectPool<BulletBehaviour> _bulletPool;

    public void Config(ObjectPool<BulletBehaviour> bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Start()
    {
        _rateOfFire = 1 / _rateOfFire; // converts from "number of bullets per second" (more intuitive) to "time between each shot" (less intuitive)
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
        _currBullet = _bulletPool.GetFreeObject();

        _currBullet.transform.position = transform.position;
        _currBullet.transform.up = transform.up;
    }
}
