using UnityEngine;


public class PooledObj : MonoBehaviour
{
    public bool IsDisabled => !gameObject.activeInHierarchy;

    public GameObject Activate()
    {
        gameObject.SetActive(true);
        return gameObject;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

