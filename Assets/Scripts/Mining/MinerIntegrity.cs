using UnityEngine;

public class MinerIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _healthPoints;

    public void Hit()
    {
        _healthPoints--;

        if (_healthPoints <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Debug.Log("Miner was killed.");
    }
}
