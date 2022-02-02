using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBaseBehaviour : MonoBehaviour
{
    [SerializeField] TMP_Text _playerScore;
    private int _totalPlayerFunds = 100;

    public int Score => _totalPlayerFunds;

    private static PlayerBaseBehaviour _instance;
    public static PlayerBaseBehaviour Instance => _instance;

    private void Awake()
    {
        _instance = this;
        SetPlayerFundsText();
    }

    private void SetPlayerFundsText()
    {
        _playerScore.SetText($"Score : {_totalPlayerFunds}");
    }

    public void IncrementScore(int value)
    {
        _totalPlayerFunds += value;
        SetPlayerFundsText();
    }

    public void DecrementScore(int value)
    {
        _totalPlayerFunds -= value;
        SetPlayerFundsText();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
