using System.Collections.Generic;
using UnityEngine;

public class TargetDesignator : Staggered_MonoBehaviour
{
    [SerializeField] private TargetTrackingBehaviour[] _turrets;
    [SerializeField] private Transform _homeBase;
    private Transform _nearestTarget;

    [SerializeField] List<EnemyMovement> enemies;

    public override void Staggered_Tick()
    {
        ScanForEnemies();
        DesignateNearestTarget();
    }

    private void ScanForEnemies()
    {
        enemies.Clear();
        enemies.AddRange(FindObjectsOfType<EnemyMovement>()); // TODO : not optimal, find a better way to do this
    }

    void DesignateNearestTarget()
    {
        _nearestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = _homeBase.position;

        foreach (var curr in enemies)
        {
            Vector3 direction = curr.transform.position - currentPosition;

            float dSqrToTarget = direction.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                _nearestTarget = curr.transform;
            }
        }

        foreach (var turret in _turrets)
        {
            turret.target = _nearestTarget;
        }
    }
}
