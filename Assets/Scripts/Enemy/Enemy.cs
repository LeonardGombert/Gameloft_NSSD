using UnityEngine;

[System.Serializable]
public class Enemy
{
    public GameObject enemyObject;

    public Enemy(GameObject enemyPrefab, EnemyData enemyData)
    {
        enemyObject = enemyPrefab;
        var enemyMovement = enemyPrefab.GetComponent<EnemyMovement>();
        enemyMovement.Init(enemyData);
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

