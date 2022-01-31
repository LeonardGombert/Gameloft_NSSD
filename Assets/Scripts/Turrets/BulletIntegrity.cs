using UnityEngine;

public class BulletIntegrity : MonoBehaviour, IDamageable
{
    public void Hit()
    {
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
