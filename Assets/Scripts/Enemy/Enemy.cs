using UnityEngine;

public class Enemy
{
    private GameObject _enemyGameObject;

    public GameObject EnemyGameObject => _enemyGameObject;
    public float Distance => _enemyGameObject.transform.position.y;
    public Transform Transform => _enemyGameObject.transform;
    public string Name => _enemyGameObject.gameObject.name;

    public Enemy(GameObject enemyPrefab, Vector3 currPos, Transform transform, EnemyData data)
    {
        _enemyGameObject = GameObject.Instantiate(enemyPrefab, currPos, Quaternion.identity, transform);

        _enemyGameObject.GetComponent<SpriteRenderer>().sprite = data.sprite;

        _enemyGameObject.GetComponent<EnemyMovement>().Init(data.moveSpeed, data.size);

        _enemyGameObject.GetComponent<EnemyIntegrity>().lifePoints = data.lifePoints;
    }
}

// classes and constructors setup in case
public class SmallEnemy : Enemy
{
    public SmallEnemy(GameObject enemyPrefab, Vector3 currPos, Transform transform, EnemyData enemyData) : base(enemyPrefab, currPos, transform, enemyData) { }
}

public class MediumEnemy : Enemy
{
    public MediumEnemy(GameObject enemyPrefab, Vector3 currPos, Transform transform, EnemyData enemyData) : base(enemyPrefab, currPos, transform, enemyData) { }
}

public class LargeEnemy : Enemy
{
    public LargeEnemy(GameObject enemyPrefab, Vector3 currPos, Transform transform, EnemyData enemyData) : base(enemyPrefab, currPos, transform, enemyData) { }
}

