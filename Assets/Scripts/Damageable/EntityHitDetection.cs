using UnityEngine;

public class EntityHitDetection : MonoBehaviour
{
    private IDamageable _entityIntegrity;
    [SerializeField] private DamagingTags _damagingTag;
    private string _damagingTagString;

    private void Awake()
    {
        _damagingTagString = _damagingTag.ToString();
        _entityIntegrity = GetComponent<IDamageable>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(_damagingTagString))
        {
            _entityIntegrity.Damage();
            Debug.Log($"{gameObject.name} hit {other.gameObject.name}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_damagingTagString))
        {
            _entityIntegrity.Damage();
            Debug.Log($"{gameObject.name} triggered by {other.gameObject.name}");
        }
    }
}
