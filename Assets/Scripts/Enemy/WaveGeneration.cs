using System.Collections;
using TMPro;
using UnityEngine;

public class WaveGeneration : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private WaveProfile[] _waveProfiles = new WaveProfile[3];
    [SerializeField] TMP_Text _currentDifficulty;

    private WaveProfile _currWaveProfile;

    private int _currWaveProfileIndex = 0;
    public int _currNumberOfWaves = 0;
    public int _maxNumberOfCurrentWaveProfile = 0;
    private int _currEnemyCount;

    private float _tickFrequency = 2.0f;
    private float _timePassed = 0.0f;
    private bool _finishedSpawning;

    private void Start()
    {
        IncrementDifficulty();
        NewWaveSize();
        NewNumberOfWaves();
        StartCoroutine(SpawnNextWave());
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
        _currNumberOfWaves = 0;
        LoadWaveData();
    }

    private void LoadWaveData()
    {
        _enemyPool.LoadNewEnemyData(_currWaveProfile.wavePreset);
    }

    private void NewWaveSize()
    {
        _currEnemyCount = Random.Range(_waveProfiles[_currWaveProfileIndex - 1].minWaveSize, _waveProfiles[_currWaveProfileIndex - 1].maxWaveSize + 1);        
    }

    private void NewNumberOfWaves()
    {
        _maxNumberOfCurrentWaveProfile = Random.Range(_currWaveProfile.minNumberOfWaves, _currWaveProfile.maxNumberOfWaves);
    }

    private void CheckWaveStatus()
    {
        if (_enemyPool.Enemies.Count == 0 && _finishedSpawning)
        {
            StartCoroutine(SpawnNextWave());
        }
    }

    private IEnumerator SpawnNextWave()
    {
        _finishedSpawning = false;

        yield return new WaitForSeconds(2f);

        _currNumberOfWaves++;

        if (_currNumberOfWaves >= _maxNumberOfCurrentWaveProfile)
        {
            Debug.Log("Going up in difficulty.");
            IncrementDifficulty();
            NewNumberOfWaves();
        }

        _currentDifficulty.SetText($"Difficulty : {(Difficulty)_currWaveProfileIndex - 1}\n Wave : {_currNumberOfWaves}");

        NewWaveSize();
        StartCoroutine(SpawnEnemies());
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
        _finishedSpawning = true;
    }
}