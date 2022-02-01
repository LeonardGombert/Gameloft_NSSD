using UnityEngine;


public class PooledObj : MonoBehaviour
{
    public bool IsDisabled => !gameObject.activeInHierarchy;

    public virtual GameObject Activate()
    {
        gameObject.SetActive(true);
        return gameObject;
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

