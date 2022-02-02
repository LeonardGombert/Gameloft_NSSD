using System;
using TMPro;
using UnityEngine;

public class MineralsIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _numberOfHitsToBreak;
    [SerializeField] TMP_Text _intergrityText;
    private int _currIntegrity;

    private float _percentage;

    public void ResetIntegrity()
    {
        _currIntegrity = _numberOfHitsToBreak;
        _intergrityText.SetText("100%");
    }

    public void Hit(GameObject otherObject = null)
    {
        _currIntegrity--;

        _percentage = (float)_currIntegrity / (float)_numberOfHitsToBreak * 100;

        _intergrityText.SetText($"{_percentage}%");
        if (_currIntegrity <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        _currIntegrity = _numberOfHitsToBreak;
        GetComponent<Pool_Object>().Deactivate();
    }
}
