using UnityEngine;

public class TargetTrackingBehaviour : MonoBehaviour
{
    [HideInInspector] public Transform target;

    void Update()
    {
        TrackTarget();
    }

    private void TrackTarget()
    {
        if (target)
        {
            transform.up = target.position - transform.position;
        }
    }
}
