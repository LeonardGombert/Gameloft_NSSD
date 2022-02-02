using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBaseBehaviour : MonoBehaviour
{
    public int totalPlayerFunds = 100;

    private static PlayerBaseBehaviour _instance;
    public static PlayerBaseBehaviour Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void IncrementScore(int value)
    {
        totalPlayerFunds += value;
        Debug.Log($"Player has {totalPlayerFunds} available for spending.");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
