using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] int enemiesToSpawn;
    [SerializeField, Tooltip("Max spacing between enemies")] private float spawnHeightIncrement = 1f;
    
    private float spawnAreaWidth;
    private const float enemySize = 1f, padding = 0.05f; // prevent enemies from spawning in sides of screen
    
    private Vector2 lastPos;
    private Vector2 currPos;

    [SerializeField] private EnemyData[] enemyData = new EnemyData[3];
    [SerializeField] private List<Enemy> spawnedEnemies = new List<Enemy>();

    private void Awake()
    {
        GetSpawnAreaWidth();
        InitStartingPosition();
    }

    private void Start()
    {
        SpawnWave();
    }

    private void GetSpawnAreaWidth() => spawnAreaWidth = Camera.main.orthographicSize * Camera.main.aspect - enemySize + padding;
    private void InitStartingPosition() => lastPos = transform.position;

    private void SpawnWave()
    {
        while (enemiesToSpawn-- != 0)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        currPos.x = Random.Range(-spawnAreaWidth, spawnAreaWidth);
        currPos.y = Random.Range(lastPos.y, lastPos.y + spawnHeightIncrement);

        GameObject spawnedEnemy = Instantiate(enemyPrefab, currPos, Quaternion.identity, transform);
        
        Enemy enemy;

        switch (Random.Range(0, 3))
        {
            default : // also serves as case 0
                enemy = new SmallEnemy(spawnedEnemy, enemyData[0]);
                break;
            case 1 :
                enemy = new MediumEnemy(spawnedEnemy, enemyData[1]);
                break;
            case 2 :
                enemy = new LargeEnemy(spawnedEnemy, enemyData[2]);
                break;
        }
        spawnedEnemies.Add(enemy);

        lastPos = currPos;
    }
}
