using UnityEngine;
using TMPro;

public class MinerIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private int _criticalHealthPoints;
    [SerializeField] TMP_Text _lifePointsText;

    public void Hit()
    {
        _healthPoints--;

        _lifePointsText.SetText($"{_healthPoints}/{_maxHealthPoints}");

        if (_healthPoints <= _criticalHealthPoints)
        {
            _lifePointsText.color = Color.red;
        }

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
