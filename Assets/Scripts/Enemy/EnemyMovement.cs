using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private int lifePoints;

    public void Init(EnemyData data)
    {
        GetComponent<SpriteRenderer>().sprite = data.sprite;
        moveSpeed = data.moveSpeed;
        lifePoints = data.lifePoints;
        transform.localScale = new Vector3(data.size, data.size, data.size);
    }

    private void Update()
    {
        transform.Translate(0, (-moveSpeed) * Time.deltaTime, 0);
    }
}
