using System;
using UnityEngine;

public class MineralsBehaviour : Pool_Object
{
    [SerializeField] private int _value;
    [SerializeField] private MineralsIntegrity _integrity;
    [SerializeField] private Transform _visuals;

    private void Update()
    {
        // TODO : timer to destroy
    }

    public override Pool_Object Activate()
    {
        _integrity.ResetIntegrity();
        return base.Activate();
    }

    public override void Deactivate()
    {
        var mineralPool = _owningPool as MineralPool;
        mineralPool.playerBase.IncrementScore(_value);
        base.Deactivate();
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public void SetScale(float size)
    {
        _visuals.localScale = new Vector3(size, size, size);
    }
}
