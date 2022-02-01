using UnityEngine;

public class EnemyIntegrity : MonoBehaviour, IDamageable
{
    [HideInInspector] public int lifePoints;

    private void Start()
    {
        
    }

    public void Hit()
    {
        lifePoints--;

        if (lifePoints == 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        GetComponent<Pool_Object>().Deactivate();
    }
}
