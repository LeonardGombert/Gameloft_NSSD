using UnityEngine;

public class BulletBehaviour : PooledObj
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxLifetime;
    private float _timePassed;

    private void Update()
    {
        TickLifetime();
    }

    void FixedUpdate()
    {
        TickMovement();
    }

    private void TickLifetime()
    {
        if (isActiveAndEnabled)
        {
            _timePassed += Time.deltaTime;
            if (_timePassed >= _maxLifetime)
            {
                _timePassed = 0.0f;
                Deactivate(); // returns the bullet to the pool
            }
        }
    }

    protected virtual void TickMovement()
    {
        transform.position = transform.position + transform.up * _speed * Time.fixedDeltaTime;
    }
}
