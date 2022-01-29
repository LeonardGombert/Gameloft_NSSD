using UnityEngine;

public class EnemyHitDetection : MonoBehaviour
{
    public EnemyDeath enemyDeath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyDeath.HitByBullet();
        }
        else
        {
            Debug.Log($"{gameObject.name} hit {collision.otherCollider.gameObject.name}");
        }
    }
}
