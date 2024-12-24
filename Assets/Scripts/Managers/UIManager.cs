using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject winPanel;

    private void OnEnable()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }
    private void OnDisable()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    #region Action Methods
    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Start:
                SetStart();
                break;

            case GameState.Game:
                SetGame();
                break;

            case GameState.Gameover:
                SetGameover();
                break;

            case GameState.Win:
                SetWin();
                break;

            default:
                break;
        }
    }
    #endregion

    #region Panel Methods
    private void SetStart()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
    private void SetGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    private void SetGameover()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }
    private void SetWin()
    {
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }
    #endregion



}
