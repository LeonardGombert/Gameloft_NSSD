using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : PooledObj
{
    private int _poolSize;
    private GameObject _poolObjectPrefab;
    private Transform _poolContainer;

    public List<T> _objectPool;
    
    public int PoolSize => _poolSize;

    public ObjectPool(int poolSize, GameObject poolObjectPrefab, Transform parent)
    {
        // configure pool params
        _poolSize = poolSize;
        _poolContainer = parent;
        _poolObjectPrefab = poolObjectPrefab;

        _objectPool = new List<T>(_poolSize);
    }

    public void FillPool()
    {
        // instantiate all necessary elements
        GameObject newObj;
        for (int i = 0; i < _poolSize; i++)
        {
            newObj = GameObject.Instantiate(_poolObjectPrefab, _poolContainer);
            _objectPool.Add(newObj.GetComponent<T>());
            newObj.SetActive(false);
        }
    }

    public GameObject GetFreeObject()
    {
        foreach (T element in _objectPool)
        {
            if (element.IsDisabled)
            {
                return element.Activate();
            }
        }
        return null;
    }
}

