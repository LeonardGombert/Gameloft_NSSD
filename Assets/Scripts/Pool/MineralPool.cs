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

    public void SpawnAtLocation(Vector3 location, MineralTypes droppedMinerals)
    {
        MineralsBehaviour mineralBlock = _mineralPool.GetFreeObject();
        mineralBlock.SetScale(droppedMinerals.size);
        mineralBlock.SetValue(droppedMinerals._value);
        mineralBlock.transform.position = location;

        mineralBlock.GetComponent<EntityHitDetection>().onStayCooldown = droppedMinerals.timeToMine;
    }
}
