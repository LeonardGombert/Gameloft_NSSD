using UnityEngine;

public interface IDamageable
{
    public void Hit(GameObject otherObject = default);

    public void Destroy();
}