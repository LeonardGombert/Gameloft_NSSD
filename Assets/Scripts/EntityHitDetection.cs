using UnityEngine;

public class EntityHitDetection : MonoBehaviour
{
    [SerializeField] private InteractiveTags _canBeHitBy;
    private string _DetectableTagString;

    [SerializeField] private float _overlapCooldown;
    private float _elapsedTime;

    private IDamageable _entityIntegrity;

    private void Awake()
    {
        _DetectableTagString = _canBeHitBy.ToString();
        _entityIntegrity = GetComponent<IDamageable>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            _entityIntegrity.Hit();
        }
    }

    // unused, but just in case
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (_elapsedTime >= _overlapCooldown)
            {
                _entityIntegrity.Hit();
                _elapsedTime = 0;
            }
            _elapsedTime += Time.fixedDeltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            _entityIntegrity.Hit();
        }
    }

    // used for mining
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (_elapsedTime >= _overlapCooldown)
            {
                _entityIntegrity.Hit();
                _elapsedTime = 0;
            }
            _elapsedTime += Time.fixedDeltaTime;
        }
    }
}