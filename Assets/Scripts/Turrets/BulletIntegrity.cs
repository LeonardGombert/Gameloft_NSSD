using UnityEngine;

public class BulletIntegrity : MonoBehaviour, IDamageable
{
    public void Hit(GameObject otherObject = null)
    {
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

}
