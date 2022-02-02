using UnityEngine;

[CreateAssetMenu(fileName = "Mineral", menuName = "ScriptableObjects/MineralType", order = 3)]
public class MineralTypes : ScriptableObject
{
    public int value;
    public float size;
    public float timeToMine;
}
