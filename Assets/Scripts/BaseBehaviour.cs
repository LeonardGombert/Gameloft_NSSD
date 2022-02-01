using System;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    private int _totalPlayerFunds;

    public void IncrementScore(int value)
    {
        _totalPlayerFunds += value;
        Debug.Log($"Player has {_totalPlayerFunds} available for spending.");
    }
}
