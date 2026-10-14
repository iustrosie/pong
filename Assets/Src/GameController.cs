using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _winText;

    [Header("Settings")]
    [SerializeField] private int _winningScore = 10;

    private static int _playerScore = 0;
    private static int _computerScore = 0;
    private static bool _isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        if (_isGameOver)
        {
            string winner = _playerScore >= _winningScore ? "Gracz" : "Komputer";
            if (_winText != null) 
            {
                _winText.text = $"{winner} wygrywa!\nNaciśnij SPACJĘ, aby zagrać od nowa";
            }
        }
        else
        {
            if (_winText != null) 
            {
                _winText.text = "Naciśnij SPACJĘ, aby rozpocząć";
            }
        }
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGameOver)
            {
                // Resetujemy punkty do 0 i uruchamiamy grę od nowa
                _playerScore = 0;
                _computerScore = 0;
                _isGameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1; // Unpause / Serwis
                if (_winText != null) _winText.text = "";
            }
        }
    }
    public void AddScore(string whoScored)
    {
        if (_isGameOver) return;

        if (whoScored == "Player") _playerScore++;
        else if (whoScored == "Computer") _computerScore++;

        // Sprawdzamy czy to koniec gry
        if (_playerScore >= _winningScore || _computerScore >= _winningScore)
        {
            _isGameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Zwykły punkt – przeładowujemy scenę do kolejnego serwu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateScoreUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"{_playerScore} : {_computerScore}";
        }
    }

    private void EndGame(string message)
    {
        _isGameOver = true;
        Time.timeScale = 0; // Zatrzymaj grę

        if (_winText != null)
        {
            _winText.text = $"{message}\nNaciśnij SPACJĘ, aby zresetować";
        }
    }
}
