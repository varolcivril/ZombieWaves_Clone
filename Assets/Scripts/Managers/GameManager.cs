using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameState gameState;

    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetGameState(GameState.Start);
    }
    private void OnEnable()
    {
        Player.OnPlayerDeath += PlayerDeathCallback;
        CountdownTimerUI.onCountdownFinished += CountdownFinishedCallback;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= PlayerDeathCallback;
        CountdownTimerUI.onCountdownFinished -= CountdownFinishedCallback;
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }
    private void PlayerDeathCallback()
    {
        SetGameState(GameState.Gameover);
    }
    private void CountdownFinishedCallback()
    {
        SetGameState(GameState.Win);
    }
    public void PlayButtonCallback()
    {
        SetGameState(GameState.Game);
    }
    public void RestartButtonCallback()
    {
        SceneManager.LoadScene(0);
    }

}
