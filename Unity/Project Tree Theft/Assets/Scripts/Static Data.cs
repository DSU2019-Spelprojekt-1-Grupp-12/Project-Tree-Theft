using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

    private static int currentLevel;


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


}
