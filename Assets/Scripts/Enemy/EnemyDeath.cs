using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int lifePoints;

    public void HitByBullet()
    {
        lifePoints--;
        Debug.Log($"{gameObject.name} was hit by a bullet.");

        if (lifePoints == 0)
        {
            Die();
            Debug.Log($"{ gameObject.name} ran out of life points.");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
