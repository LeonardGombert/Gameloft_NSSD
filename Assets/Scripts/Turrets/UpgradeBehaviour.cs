using System;
using TMPro;
using UnityEngine;

public class UpgradeBehaviour : MonoBehaviour
{
    [SerializeField] private TargetTrackingBehaviour _targetTracking;
    [SerializeField] private ShootingBehaviour _shootingBehaviour;
    [SerializeField] private TMP_Text _upgradeText;

    private bool IsActive = false;
    private int _upgradeCost = 100;

    private PlayerBaseBehaviour _playerBase;

    private void Start()
    {
        _playerBase = PlayerBaseBehaviour.Instance;

        IsActive = false;
        _targetTracking.enabled = false;
        _shootingBehaviour.enabled = false;
        _upgradeText.SetText($"Activate Turret : {_upgradeCost}");  
    }

    public void PurchaseUpgrade()
    {
        if(_playerBase.Score >= _upgradeCost)
        {
            if (IsActive)
            {
                UpgradeFireRate();
            }
            else
            {
                ActivateTurret();
            }

            _playerBase.DecrementScore(_upgradeCost);
        }
    }

    private void UpgradeFireRate()
    {
        _shootingBehaviour.UpgradeFiringRate();
        _upgradeText.SetText($"Upgrade Turret : {_upgradeCost}");
    }

    private void ActivateTurret()
    {
        IsActive = true;
        _targetTracking.enabled = true;
        _shootingBehaviour.enabled = true;
        _upgradeText.SetText($"Upgrade Turret : {_upgradeCost}");
    }
}
