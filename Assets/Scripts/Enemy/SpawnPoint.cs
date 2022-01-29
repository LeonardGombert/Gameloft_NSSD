using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] int enemiesToSpawn;
    [SerializeField, Tooltip("Max spacing between enemies")] private float spawnHeightIncrement = 1f;
    
    private float spawnAreaWidth;
    private const float enemySize = 1f, padding = 0.05f; // prevent enemies from spawning in sides of screen
    
    private Vector2 lastPos;
    private Vector2 currPos;

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

        Instantiate(enemyPrefab, currPos, Quaternion.identity);

        lastPos = currPos;
    }
}
