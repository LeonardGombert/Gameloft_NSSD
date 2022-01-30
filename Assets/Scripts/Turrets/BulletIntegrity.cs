using UnityEngine;

public class BulletIntegrity : MonoBehaviour, IDamageable
{
    public void Hit()
    {
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Debug.LogWarning($"Deactivating {gameObject.name}");
    }
}
