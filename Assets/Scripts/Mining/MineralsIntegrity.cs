using UnityEngine;

public class MineralsIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _numberOfHitsToBreak;
    private int _currIntegrity;

    private void Start()
    {
        _currIntegrity = _numberOfHitsToBreak;
    }

    public void Hit()
    {
        _currIntegrity--;

        if (_currIntegrity <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        _currIntegrity = _numberOfHitsToBreak;
    }
}
