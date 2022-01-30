using UnityEngine;

public class EntityHitDetection : MonoBehaviour
{
    [SerializeField] private DamagingTags _DetectableTag;
    private string _DetectableTagString;

    private IDamageable _entityIntegrity;

    private void Awake()
    {
        _DetectableTagString = _DetectableTag.ToString();
        _entityIntegrity = GetComponent<IDamageable>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            _entityIntegrity.Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_DetectableTagString))
        {
            _entityIntegrity.Hit();
        }
    }
}