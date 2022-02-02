using UnityEngine;

/// <summary>
/// A simple "functionality-agnostic" implementation for collisions. Allows you to specifiy which tag the actor detects, which will
/// get the IDamageable Component attached to this class and raise the Hit() function.
/// Reduces boilerplate, as this code would essentially have been copy-pasted into oblivion anyway.
/// </summary> 

public class EntityHitDetection : MonoBehaviour
{
    [SerializeField] private InteractiveTag _canBeHitBy;
    [SerializeField] private ComplexInteractionTypes _hitTypes;
    [SerializeField] public float onStayCooldown;
    private string _DetectableTagString;

    private float _elapsedTime;

    private IDamageable _entityIntegrity;

    private void Awake()
    {
        _DetectableTagString = _canBeHitBy.ToString();
        _entityIntegrity = GetComponent<IDamageable>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString) && _hitTypes.HasFlag(ComplexInteractionTypes.CollisionEnter))
        {
            _entityIntegrity.Hit(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString) && _hitTypes.HasFlag(ComplexInteractionTypes.CollisionStay))
        {
            GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (_elapsedTime >= onStayCooldown)
            {
                _entityIntegrity.Hit(other.gameObject);
                _elapsedTime = 0;
            }
            _elapsedTime += Time.fixedDeltaTime;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString) && _hitTypes.HasFlag(ComplexInteractionTypes.TriggerEnter))
        {
            _entityIntegrity.Hit(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString) && _hitTypes.HasFlag(ComplexInteractionTypes.TriggerStay))
        {
            GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (_elapsedTime >= onStayCooldown)
            {
                _entityIntegrity.Hit(other.gameObject);
                _elapsedTime = 0;
            }
            _elapsedTime += Time.fixedDeltaTime;
        }
    }
}