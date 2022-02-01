using System;
using UnityEngine;

public class MineralsBehaviour : Pool_Object
{
    [SerializeField] private int _value;

    private void Update()
    {
        // timer to destroy
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

    public void SetVisuals(Sprite visual, float size)
    {
        transform.localScale = new Vector3(size, size, size);
        GetComponent<SpriteRenderer>().sprite = visual;
    }
}
