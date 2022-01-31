using UnityEngine;

public class MineralsBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private int _numberOfHitsToBreak;

    public void Hit()
    {
        _numberOfHitsToBreak--;

        if (_numberOfHitsToBreak <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Debug.Log("Was destroyed. Spawning money.");

        gameObject.SetActive(false);
    }
}
