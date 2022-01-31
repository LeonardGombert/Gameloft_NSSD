using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Staggered_MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField, Tooltip("Max spacing between enemies")] private float _spawnHeightIncrement = 1f;

    private float _spawnAreaWidth;
    private const float _enemySize = 1f, _padding = 0.05f; // prevent enemies from spawning in sides of screen

    private Vector2 _lastPos;
    private Vector2 _currPos;

    [SerializeField] private EnemyData[] _enemyData = new EnemyData[3];
    [SerializeField] private List<GameObject> enemyObjects = new List<GameObject>();

    private void Awake()
    {
        GetSpawnAreaWidth();
        InitStartingPosition();
    }

    private void Start()
    {
        SpawnWave();
    }

    private void GetSpawnAreaWidth() => _spawnAreaWidth = Camera.main.orthographicSize * Camera.main.aspect - _enemySize + _padding;
    private void InitStartingPosition() => _lastPos = transform.position;
   
    public override void Staggered_Tick()
    {
        for (int i = enemyObjects.Count - 1; i > 0; i--)
        {
            if (!enemyObjects[i])
            {
                enemyObjects.RemoveAt(i);
            }
        }
    }

    private void SpawnWave()
    {
        while (_enemiesToSpawn-- != 0)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        _currPos.x = Random.Range(-_spawnAreaWidth, _spawnAreaWidth);
        _currPos.y = Random.Range(_lastPos.y, _lastPos.y + _spawnHeightIncrement);

        Enemy spawnedEnemy;

        switch (Random.Range(0, _enemyData.Length - 1))
        {
            default: // also serves as case 0
                spawnedEnemy = new SmallEnemy(_enemyPrefab, _currPos, transform, _enemyData[0]);
                break;
            case 1:
                spawnedEnemy = new MediumEnemy(_enemyPrefab, _currPos, transform, _enemyData[1]);
                break;
            case 2:
                spawnedEnemy = new LargeEnemy(_enemyPrefab, _currPos, transform, _enemyData[2]);
                break;
        }

        enemyObjects.Add(spawnedEnemy.EnemyGameObject);

        _lastPos = _currPos;
    }
}
