using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBaseIntegrity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxLifePoints;
    [SerializeField] private Slider _lifePointsSlider;
    private int _currentLifePoints;
    [SerializeField] private UnityEvent _gameOver;

    private void Start()
    {
        _currentLifePoints = _maxLifePoints;
        SetSliderValue();
    }

    public void Hit(GameObject otherObject)
    {
        _currentLifePoints--;

        SetSliderValue();

        otherObject.GetComponent<Pool_Object>().Deactivate();

        if (_currentLifePoints <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        _gameOver.Invoke();
    }

    private void SetSliderValue()
    {
        _lifePointsSlider.value = _currentLifePoints;
    }
}
