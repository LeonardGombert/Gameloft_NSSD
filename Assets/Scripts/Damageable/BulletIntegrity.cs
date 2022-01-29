using UnityEngine;

public class BulletIntegrity : MonoBehaviour, IDamageable
{
    public void Damage()
    {
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log($"Deactivating {gameObject.name}");
    }
}
