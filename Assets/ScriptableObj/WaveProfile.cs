using UnityEngine;

[CreateAssetMenu(fileName ="WaveProfile", menuName ="ScriptableObjects/WaveProfile", order = 2)]
public class WaveProfile : ScriptableObject
{
    private int _smallEnemyPercentage;
    private int _mediumEnemyPercentage;
    private int _largeEnemyPercentage;
}
