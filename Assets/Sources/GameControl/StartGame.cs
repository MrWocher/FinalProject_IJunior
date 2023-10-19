using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent GameStarted;
    [SerializeField] private UnityEvent GameFinished;
    [SerializeField] private UnityEvent StopPlayer;
    [SerializeField] private UnityEvent StartPlayer;
    [SerializeField] private UnityEvent GameOver;

    public void OnStartGame()
    {
        GameStarted?.Invoke();
    }

    public void OnGameFinish()
    {
        GameFinished?.Invoke();
    }

    public void OnStopPlayer()
    {
        StopPlayer?.Invoke();
    }

    public void OnContinuePlayer()
    {
        StartPlayer?.Invoke();
    }

    public void OnGameOver()
    {
        GameOver?.Invoke();
    }
}
