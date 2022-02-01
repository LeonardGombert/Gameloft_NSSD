using UnityEngine;

public class Pool_Object : MonoBehaviour
{
    protected Pool _owningPool;
    
    public void SetOwningPool(Pool owningPool)
    {
        _owningPool = owningPool;
    }

    public bool IsDisabled => !gameObject.activeInHierarchy;

    public virtual Pool_Object Activate()
    {
        gameObject.SetActive(true);
        return this;
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

