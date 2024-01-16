using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PigGenerator _pigGenerator;
    [SerializeField] private BulletsPool _bulletsPool;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Awake()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.StartButtonClick += OnStartButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClick -= OnStartButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pigGenerator.ResetPool();
        _bulletsPool.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _bird.ResetPlayer();
    }

    private void OnGameOver()
    {
        _pigGenerator.StopShooting();
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
