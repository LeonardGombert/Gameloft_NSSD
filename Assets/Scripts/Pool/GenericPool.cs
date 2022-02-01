using System;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T> where T : Pool_Object
{
    private int _poolSize;
    private GameObject _poolObjectPrefab;
    private Transform _poolContainer;

    public List<T> _objectPool;
    
    public int PoolSize => _poolSize;

    public GenericPool(int poolSize, GameObject poolObjectPrefab, Transform parent)
    {
        // configure pool params
        _poolSize = poolSize;
        _poolContainer = parent;
        _poolObjectPrefab = poolObjectPrefab;

        _objectPool = new List<T>(_poolSize);
    }

    public void FillPool(Pool owningPool)
    {
        // instantiate all necessary elements
        GameObject newObj;
        for (int i = 0; i < _poolSize; i++)
        {
            newObj = GameObject.Instantiate(_poolObjectPrefab, _poolContainer);
            newObj.SetActive(false);

            var spawnedObj = newObj.GetComponent<T>();
            spawnedObj.SetOwningPool(owningPool);
            _objectPool.Add(spawnedObj);
        }
    }

    public T GetFreeObject()
    {
        foreach (T element in _objectPool)
        {
            if (element.IsDisabled)
            {
                return element.Activate() as T;
            }
        }
        return null;
    }
}

