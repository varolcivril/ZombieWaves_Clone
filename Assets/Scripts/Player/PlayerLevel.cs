using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int currentExp = 0;
    private int maxExp = 100;
    private int currentLevel = 1;

    private void OnEnable()
    {
        //ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
        //ExperienceManager.Instance.OnExperienceChangeAction += HandleExperienceChange;
    }

    private void OnDisable()
    {
        //ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
        //ExperienceManager.Instance.OnExperienceChangeAction -= HandleExperienceChange;
    }
    public void HandleExperienceChange(int expAmount)
    {
        currentExp += expAmount;
        Debug.LogWarning($"Experience Handler: New current exp {currentExp}.");
        if (currentExp >= maxExp)
        {
            currentExp = 0;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        maxExp += 100;
        Debug.Log($"Level up! New level {currentLevel}, new Max Exp {maxExp}.");
    }
}
