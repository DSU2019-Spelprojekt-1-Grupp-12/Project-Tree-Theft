﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

    private static int currentLevel = 0;

    public static int currentScore = 0;


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
            return Score;
        }
        set
        {
            currentScore = value;
        }
    }


}
