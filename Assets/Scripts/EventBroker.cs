using System;
using UnityEngine;

public class EventBroker
{
    public static event Action<GameObject> StackableCubeTriggered;
    public static event Action<GameObject> StackableCubeInvisible;
    public static event Action<GameObject> ObstacleCubeCollided;
    public static event Action<GameObject> CubeAbsorbed;

    public static event Action<int> UpdateMoney;

    public static event Action LevelStarted;
    public static event Action LevelCompleted;
    public static event Action LevelFailed;

    public static void CallStackableCubeTriggered(GameObject gameObject)
    {
        StackableCubeTriggered?.Invoke(gameObject);
    }

    public static void CallStackableCubeInvisible(GameObject gameObject)
    {
        StackableCubeInvisible?.Invoke(gameObject);
    }

    public static void CallObstacleCubeCollided(GameObject gameObject)
    {
        ObstacleCubeCollided?.Invoke(gameObject);
    }

    public static void CallCubeAbsorbed(GameObject gameObject)
    {
        CubeAbsorbed?.Invoke(gameObject);
    }

    public static void CallLevelStarted()
    {
        LevelStarted?.Invoke();
    }

    public static void CallLevelFinished()
    {
        LevelCompleted?.Invoke();
    }

    public static void CallLevelFailed()
    {
        LevelFailed?.Invoke();
    }

    public static void CallUpdateMoney(int value)
    {
        UpdateMoney?.Invoke(value);
    }
}
