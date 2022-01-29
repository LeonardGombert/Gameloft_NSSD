using UnityEngine;

[System.Serializable]
public class Enemy
{
    private GameObject _enemy;

    public Enemy(GameObject prefab, EnemyData data)
    {
        _enemy = prefab;

        prefab.GetComponent<SpriteRenderer>().sprite = data.sprite;

        prefab.GetComponent<EnemyMovement>().Init(data.moveSpeed, data.size);

        prefab.GetComponent<EnemyIntegrity>().lifePoints = data.lifePoints;
    }
}

// classes and constructors setup in case
public class SmallEnemy : Enemy
{
    public SmallEnemy(GameObject enemyPrefab, EnemyData enemyData) : base(enemyPrefab, enemyData) { }
}

public class MediumEnemy : Enemy
{
    public MediumEnemy(GameObject enemyPrefab, EnemyData enemyData) : base(enemyPrefab, enemyData) { }
}

public class LargeEnemy : Enemy
{
    public LargeEnemy(GameObject enemyPrefab, EnemyData enemyData) : base(enemyPrefab, enemyData) { }
}

