using System;
using UnityEngine;

public class EnemyBehaviour : PooledObj
{
    private float _moveSpeed;
    public Vector3 Positon => transform.position;

    public void Config(EnemyData enemyData)
    {
        GetComponent<SpriteRenderer>().sprite = enemyData.sprite;
        GetComponent<EnemyIntegrity>().lifePoints = enemyData.lifePoints;
        _moveSpeed = enemyData.moveSpeed;
        transform.localScale = new Vector3(enemyData.size, enemyData.size, enemyData.size);
    }

    private void Update()
    {
        transform.Translate(0, (-_moveSpeed) * Time.deltaTime, 0);
    }
}