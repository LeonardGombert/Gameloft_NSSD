using UnityEngine;

public class EnemyIntegrity : MonoBehaviour, IDamageable
{
    [HideInInspector] public int lifePoints;

    public void Hit()
    {
        lifePoints--;

        if (lifePoints == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
