using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : Pool
{
    [SerializeField] private MineralPool _mineralPool;

    [SerializeField] private List<GameObject> spawnedEnemies = new List<GameObject>();
    private List<EnemyData> _enemyData = new List<EnemyData>();

    private GenericPool<EnemyBehaviour> _enemyPool;

    private float _spawnAreaWidth;
    private const float _enemySize = 1f, _padding = 0.05f; // prevent enemies from spawning in sides of screen
    private float _tickFrequency = 0.0f;
    private float _timePassed = 0.0f;
    private Vector2 _currPos;

    public List<GameObject> Enemies => spawnedEnemies;

    void Awake()
    {
        _enemyPool = new GenericPool<EnemyBehaviour>(_poolSize, _poolObjectPrefab, transform);
        _enemyPool.FillPool(this);

        GetSpawnAreaWidth();
    }

    void Update()
    {
        if (_timePassed >= _tickFrequency)
        {
            RemoveEmpties();

            _timePassed = 0;
            _tickFrequency = Random.Range(0.01f, 0.1f);
        } // ticks occur irregularly.
        _timePassed += Time.deltaTime;
    }

    private void GetSpawnAreaWidth() => _spawnAreaWidth = Camera.main.orthographicSize * Camera.main.aspect - _enemySize + _padding;


    public void ActivateEnemy()
    {
        _currPos.x = Random.Range(-_spawnAreaWidth, _spawnAreaWidth);
        _currPos.y = Random.Range(transform.position.y, transform.position.y + 1);

        EnemyBehaviour enemy = _enemyPool.GetFreeObject();
        enemy.gameObject.transform.position = _currPos;
        enemy.gameObject.transform.parent = transform;

        enemy.Config(_enemyData[Random.Range(0, _enemyData.Count)], _mineralPool);

        spawnedEnemies.Add(enemy.gameObject);
    }

    public void RemoveEmpties()
    {
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i].GetComponent<Pool_Object>().IsDisabled)
            {
                spawnedEnemies.RemoveAt(i);
            }
        }
    }

    public void LoadNewEnemyData(List<EnemyData> wavePreset)
    {
        _enemyData = wavePreset;
    }
}
