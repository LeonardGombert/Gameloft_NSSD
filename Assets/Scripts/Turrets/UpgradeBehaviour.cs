using System;
using UnityEngine;

public class UpgradeBehaviour : MonoBehaviour
{
    [SerializeField] private TargetTrackingBehaviour _targetTracking;
    [SerializeField] private ShootingBehaviour _shootingBehaviour;
    private bool IsActive = false;

    private void Start()
    {
        IsActive = false;
        _targetTracking.enabled = false;
        _shootingBehaviour.enabled = false;
    }

    public void PurchaseUpgrade()
    {
        if (IsActive)
        {
            UpgradeFireRate();
        }
        else
        {
            ActivateTurret();
        }
    }

    private void UpgradeFireRate()
    {
        _shootingBehaviour.UpgradeFiringRate();
    }

    private void ActivateTurret()
    {
        IsActive = true;
        _targetTracking.enabled = true;
        _shootingBehaviour.enabled = true;
    }
}
