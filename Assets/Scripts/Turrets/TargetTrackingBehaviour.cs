using System.Collections.Generic;
using UnityEngine;

public class TargetTrackingBehaviour : MonoBehaviour
{
    [HideInInspector] private static Transform commonTarget; // all turret instances share the same target
    [SerializeField] private EnemyPool _enemyPool;

    [SerializeField] private Transform _homeBase;
    [SerializeField] private Transform _turretVisuals;
    private Transform _nearestTarget;

    private float _tickFrequency = 0.0f;
    private float _timePassed = 0.0f;

    void Update()
    {
        if (_timePassed >= _tickFrequency)
        {
            DesignateNearestTarget();

            _timePassed = 0;
            _tickFrequency = Random.Range(0.01f, 0.1f);
        } // ticks occur irregularly. Decreases chance of overlapping ticks of the same nature.
        _timePassed += Time.deltaTime;

        TrackTarget();
    }

    void DesignateNearestTarget()
    {
        _nearestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = _homeBase.position;

        foreach (var curr in _enemyPool.Enemies)
        {
            Vector3 direction = curr.transform.position - currentPosition;

            float dSqrToTarget = direction.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                _nearestTarget = curr.transform;
            }
        }

        commonTarget = _nearestTarget;
    }

    private void TrackTarget()
    {
        if (commonTarget)
        {
            _turretVisuals.up = commonTarget.position - transform.position;
        }
    }
}
