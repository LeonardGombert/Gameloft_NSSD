using System;
using TMPro;
using UnityEngine;

public class EnemyIntegrity : MonoBehaviour, IDamageable
{
    [HideInInspector] private int _lifePoints;
    [SerializeField] public TMP_Text _lifePointsText;

    public void Hit()
    {
        _lifePoints--;

        _lifePointsText.SetText($"{_lifePoints}");

        if (_lifePoints == 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        GetComponent<Pool_Object>().Deactivate();
    }

    public void ResetLifePoints(int lifePoints)
    {
        _lifePoints = lifePoints;
        _lifePointsText.SetText($"{lifePoints}");
    }
}
