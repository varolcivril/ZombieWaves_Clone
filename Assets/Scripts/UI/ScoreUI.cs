using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Image fillImage;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI experiencePercentageText;
    public TextMeshProUGUI zombieKillsGameText, zombieKillsGameoverText, zombieKillsWinText;

    private int currentExp = 0;
    private int maxExp = 100;
    private int currentLevel = 1;

    private int zombiesKilled = 0;

    private void OnEnable()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
        Enemy.onEnemyDeath += EnemyDeathCallback;
    }
    private void OnDisable()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        Enemy.onEnemyDeath -= EnemyDeathCallback;
    }
    private void Start()
    {
        UpdateUI();
    }

    public void AddExperience(int expAmount)
    {
        currentExp += expAmount;
        zombiesKilled++;
        UpdateUI();
        Debug.LogWarning($"Experience Handler: New current exp {currentExp}.");
        if (currentExp >= maxExp)
        {
            currentExp = 0;
            LevelUp();
        }
        Debug.Log("Experience recieved.");
    }
    private void LevelUp()
    {
        currentLevel++;
        maxExp += 100;
        UpdateUI();
        Debug.Log($"Level up! New level {currentLevel}, new Max Exp {maxExp}.");
    }

    private void UpdateUI()
    {
        levelText.text = currentLevel.ToString();
        experiencePercentageText.text = $"{Math.Round((float)currentExp / (float)maxExp * 100)}%";
        fillImage.fillAmount = (float)currentExp / (float)maxExp;
        zombieKillsGameText.text = zombiesKilled.ToString();  
    }

    #region Action Methods
    private void EnemyDeathCallback(int amount)
    {
        AddExperience(amount);
    }
    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Start:
                break;
            case GameState.Game:
                break;
            case GameState.Gameover:
                zombieKillsGameoverText.text = $"Zombies killed: {zombiesKilled.ToString()}";
                break;
            case GameState.Win:
                zombieKillsWinText.text = $"Zombies killed: {zombiesKilled.ToString()}";
                break;
            default:
                break;
        }
    }
    #endregion
}
