using UnityEngine;

public class BulletMovement : MonoBehaviour
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
                gameObject.SetActive(false);
            }
        }
    }

    public void TickMovement()
    {
        transform.Translate(transform.up * _speed * Time.fixedDeltaTime);
    }
}
