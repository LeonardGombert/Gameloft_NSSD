using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    private GameObject _currBullet;

    [SerializeField, Tooltip("The number of bulets to fire per second.")] private float _rateOfFire;
    private float _timePassed;

    [SerializeField] private Vector3 _barrelTip;    

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
            Shoot();
        }
    }

    private void Shoot()
    {
        _currBullet = _bulletPool.GetFreeBullet();

        if (_currBullet)
        {
            _currBullet.transform.position = transform.position + _barrelTip;
            _currBullet.transform.up = transform.up;
            _currBullet.SetActive(true);
        }
    }
}
