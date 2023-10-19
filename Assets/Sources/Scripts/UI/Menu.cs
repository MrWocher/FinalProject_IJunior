using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private StartGame _startGame;

    public void StartGame()
    {
        _startGame.OnStartGame();
        gameObject.SetActive(false);
    }
}
