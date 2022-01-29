using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField, Tooltip("Max spacing between enemies")] private float _spawnHeightIncrement = 1f;
    
    private float _spawnAreaWidth;
    private const float _enemySize = 1f, _padding = 0.05f; // prevent enemies from spawning in sides of screen
    
    private Vector2 _lastPos;
    private Vector2 _currPos;

    [SerializeField] private EnemyData[] _enemyData = new EnemyData[3];

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

        GameObject spawnedEnemy = Instantiate(_enemyPrefab, _currPos, Quaternion.identity, transform);
        
        switch (Random.Range(0, 3))
        {
            default : // also serves as case 0
                new SmallEnemy(spawnedEnemy, _enemyData[0]);
                break;
            case 1 :
                new MediumEnemy(spawnedEnemy, _enemyData[1]);
                break;
            case 2 :
                new LargeEnemy(spawnedEnemy, _enemyData[2]);
                break;
        }

        _lastPos = _currPos;
    }
}
