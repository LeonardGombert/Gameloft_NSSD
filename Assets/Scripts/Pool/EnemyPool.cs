using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField, Tooltip("Max spacing between enemies")] private float _spawnHeightIncrement = 1f;

    private float _spawnAreaWidth;
    private const float _enemySize = 1f, _padding = 0.05f; // prevent enemies from spawning in sides of screen

    private Vector2 _currPos;

    [SerializeField] private EnemyData[] _enemyData = new EnemyData[3];
    [SerializeField] private List<GameObject> _spawnedEnemies = new List<GameObject>();

    public Queue<EnemyBehaviour> enemyWave = new Queue<EnemyBehaviour>();

    [SerializeField] private int _enemyPoolSize;
    [SerializeField] private GameObject _enemyPrefab;

    private ObjectPool<EnemyBehaviour> _enemyPool;

    // Start is called before the first frame update
    void Awake()
    {
        _enemyPool = new ObjectPool<EnemyBehaviour>(_enemyPoolSize, _enemyPrefab, transform);
        _enemyPool.FillPool();

        GetSpawnAreaWidth();
    }

    private void Start()
    {
        SpawnWave();
    }

    private void GetSpawnAreaWidth() => _spawnAreaWidth = Camera.main.orthographicSize * Camera.main.aspect - _enemySize + _padding;

    public void RemoveEmpties()
    {
        for (int i = _spawnedEnemies.Count - 1; i > 0; i--)
        {
            if (!_spawnedEnemies[i])
            {
                _spawnedEnemies.RemoveAt(i);
            }
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < _enemyPoolSize; i++)
        {
            _currPos.x = Random.Range(-_spawnAreaWidth, _spawnAreaWidth);
            _currPos.y = transform.position.y;

            GameObject newObj = _enemyPool.GetFreeObject();
            newObj.transform.position = _currPos;
            newObj.transform.parent = transform;

            EnemyBehaviour enemy = newObj.GetComponent<EnemyBehaviour>();

            switch (Random.Range(0, _enemyData.Length - 1))
            {
                default: // also serves as case 0
                    enemy.Config(_enemyData[0]);
                    break;
                case 1:
                    enemy.Config(_enemyData[1]);
                    break;
                case 2:
                    enemy.Config(_enemyData[2]);
                    break;
            }

            _spawnedEnemies.Add(newObj);
            enemy.Deactivate();
        }
    }

    private void Activate()
    {
        int index = 0;

        enemyWave.Enqueue(_spawnedEnemies[index].GetComponent<EnemyBehaviour>());
        _spawnedEnemies.RemoveAt(index);
    }
}
