using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WaveProfile", menuName ="ScriptableObjects/WaveProfile", order = 2)]
public class WaveProfile : ScriptableObject
{
    public List<EnemyData> wavePreset;

    public float minimumTimeToSpawn;
    public float maxTimeToSpawn;

    public int minNumberToSpawn;
    public int maxNumberToSpawn;

    public int minWaveSize;
    public int maxWaveSize;

    public int minNumberOfWaves;
    public int maxNumberOfWaves;
}