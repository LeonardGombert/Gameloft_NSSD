using UnityEngine;

public class MineralPool : Pool
{
    private GenericPool<MineralsBehaviour> _mineralPool;
    public BaseBehaviour playerBase;

    void Awake()
    {
        _mineralPool = new GenericPool<MineralsBehaviour>(_poolSize, _poolObjectPrefab, transform);
        _mineralPool.FillPool(this);
    }

    public void SpawnAtLocation(Vector3 location)
    {
        MineralsBehaviour mineralBlock = _mineralPool.GetFreeObject();
        mineralBlock.SetValue(Random.Range(1, 15));
        mineralBlock.transform.position = location;
    }
}
