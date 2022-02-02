using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public float moveSpeed;
    public int lifePoints;
    public float size;
    public Color color;
    public EnemyTypes enemyType;
    public MineralTypes droppedMinerals;
}
