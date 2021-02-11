using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private StartGameButtonView _startGameButton;
    private QuitGameButtonView _quitGameButton;
    private static string _playerScore;
    private GameObject _player;
    private int _score;

    private Button _startButton;
    private Button _quitButton;


    private void Start()
    {
        _startButton = GameObject.FindGameObjectWithTag("Start").GetComponent<Button>();
        _startGameButton = _startButton.GetComponent<StartGameButtonView>();

        _quitButton = GameObject.FindGameObjectWithTag("Quit").GetComponent<Button>();
        _quitGameButton = _quitButton.GetComponent<QuitGameButtonView>();

        _startButton.onClick.AddListener(_startGameButton.Execute);
        _quitButton.onClick.AddListener(_quitGameButton.Execute);
    }
}
