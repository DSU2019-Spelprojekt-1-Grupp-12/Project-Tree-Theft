using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    private static int currentLevel = 1;
    private static int currentScore;
    private static int overallScore;

    private static int clearedLevels = 0;
    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }
    public static int NextLevel
    {
        get
        {
            return currentLevel + 1;
        }

    }
    public static int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
        }
    }
    public static int PlayerScore
    {
        get
        {
            return overallScore;
        }
        set
        {
            overallScore = value;
        }
    }
    public static int ClearedLevels
    {
        get
        {
            return clearedLevels;
        }
    }
    public static void AddScore(int score)
    {
        currentScore += score;
    }
    public static void SetPlayerScore()
    {
        overallScore += currentScore;
        currentScore = 0;
    }
    public static void ClearLevel()
    {
        if (currentLevel >= clearedLevels)
        {
            clearedLevels = currentLevel + 1;
        }
    }
    public static void ResetData()
    {
        currentScore = 0;
        currentLevel = 0;
        overallScore = 0;
    }
}
