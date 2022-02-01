using UnityEngine;

public class MineralsBehaviour : Pool_Object
{
    [SerializeField] private int _value;

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
}
