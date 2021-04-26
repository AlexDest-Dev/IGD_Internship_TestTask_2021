using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeToPlayUI : MonoBehaviour
{
    private void Start()
    {
        EventBroker.LevelStarted += DisableSwipeToPlay;
    }

    private void DisableSwipeToPlay()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventBroker.LevelStarted -= DisableSwipeToPlay;
    }
}
