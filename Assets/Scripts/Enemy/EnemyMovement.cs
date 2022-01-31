using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _moveSpeed;

    public void Init(float moveSpeed, float size)
    {
        _moveSpeed = moveSpeed;
        transform.localScale = new Vector3(size, size, size);
    }

    private void Update()
    {
        transform.Translate(0, (-_moveSpeed) * Time.deltaTime, 0);
    }
}
