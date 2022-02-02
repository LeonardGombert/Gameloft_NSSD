using UnityEngine;
using UnityEngine.Events;

public class PlayerBaseIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _lifePoints;
    [SerializeField] private UnityEvent _gameOver;


    public void Hit(GameObject otherObject)
    {
        otherObject.GetComponent<Pool_Object>().Deactivate();

        _lifePoints--;

        if (_lifePoints <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        _gameOver.Invoke();
    }
}
