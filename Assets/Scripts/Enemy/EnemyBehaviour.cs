using System;
using UnityEngine;

public class EnemyBehaviour : Pool_Object
{
    private MineralPool _mineralPool;
    private EnemyData _enemyData;
    private float _moveSpeed;

    public Vector3 Positon => transform.position;

    public void Config(EnemyData enemyData, MineralPool mineralPool)
    {
        _enemyData = enemyData;
        _mineralPool = mineralPool;

        _moveSpeed = _enemyData.moveSpeed;
        GetComponent<SpriteRenderer>().sprite = enemyData.sprite;
        GetComponent<EnemyIntegrity>().lifePoints = enemyData.lifePoints;
        transform.localScale = new Vector3(enemyData.size, enemyData.size, enemyData.size);
    }

    private void Update()
    {
        transform.Translate(0, (-_moveSpeed) * Time.deltaTime, 0);
    }

    public override void Deactivate()
    {
        var random = UnityEngine.Random.Range(0, 1);

        if (random >= _enemyData.size)
        {
            _mineralPool.SpawnAtLocation(Positon);
        }

        base.Deactivate();
    }
}
