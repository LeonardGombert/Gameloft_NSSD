using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;

    private void Update()
    {
        transform.Translate(0, (-speed) * Time.deltaTime, 0);
    }
}
