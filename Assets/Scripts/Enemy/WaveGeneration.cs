using System.Collections;
using UnityEngine;

public class WaveGeneration : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private WaveProfile[] _waveProfiles = new WaveProfile[3];

    private WaveProfile _currWaveProfile;

    private int _currWaveProfileIndex = 0;
    private int _currNumberOfWaves = 0;
    private int _maxNumberOfCurrentWaveProfile = 0;
    private int _currEnemyCount;

    private float _tickFrequency = 2.0f;
    private float _timePassed = 0.0f;

    private void Start()
    {
        IncrementDifficulty();
        NewWaveSize();
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        if (_timePassed >= _tickFrequency)
        {
            CheckWaveStatus();

            _timePassed = 0;
            _tickFrequency = Random.Range(1f, 3f);
        } // ticks occur irregularly.
        _timePassed += Time.deltaTime;
    }

    public void IncrementDifficulty()
    {
        _currWaveProfile = _waveProfiles[_currWaveProfileIndex++];
        LoadWaveData();
    }

    private void LoadWaveData()
    {
        _enemyPool.LoadNewEnemyData(_currWaveProfile.wavePreset);
    }

    private void NewWaveSize()
    {
        _currEnemyCount = Random.Range(_waveProfiles[_currWaveProfileIndex-1].minWaveSize, _waveProfiles[_currWaveProfileIndex - 1].maxWaveSize + 1);
    }

    private IEnumerator SpawnEnemies()
    {
        if (_currEnemyCount > 0)
        {
            var numberToSpawn = Random.Range(_currWaveProfile.minNumberToSpawn, _currWaveProfile.maxNumberToSpawn + 1);
            var timeToNextSpawn = Random.Range(_currWaveProfile.minimumTimeToSpawn, _currWaveProfile.maxTimeToSpawn + 1);

            for (int i = 0; i < numberToSpawn; i++)
            {
                _enemyPool.ActivateEnemy();

                _currEnemyCount--;
            }

            yield return new WaitForSeconds(timeToNextSpawn);

            StartCoroutine(SpawnEnemies());
        }
        else
        {
            yield return null;
        }
    }

    public IEnumerator SpawnNextWave()
    {
        yield return new WaitForSeconds(2f);
        
        _currNumberOfWaves++;

        if (_currNumberOfWaves >= _maxNumberOfCurrentWaveProfile)
        {
            Debug.Log("Going up in difficulty.");
            IncrementDifficulty();
            _maxNumberOfCurrentWaveProfile = Random.Range(_currWaveProfile.minNumberOfWaves, _currWaveProfile.maxNumberOfWaves);
        }

        NewWaveSize();
        StartCoroutine(SpawnEnemies());
    }


    private void CheckWaveStatus()
    {
        if (_enemyPool.Enemies.Count == 0)
        {
            StartCoroutine(SpawnNextWave());
        }
    }
}