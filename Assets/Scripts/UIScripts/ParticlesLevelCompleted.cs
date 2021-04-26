using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesLevelCompleted : MonoBehaviour
{
    private ParticleSystem _victoryParticles;
    private void Start()
    {
        _victoryParticles = GetComponent<ParticleSystem>();
        _victoryParticles.gameObject.SetActive(false);
        EventBroker.LevelCompleted += EnableParticles;
    }

    private void EnableParticles()
    {
        _victoryParticles.gameObject.SetActive(true);
        _victoryParticles.Play();
    }

    private void OnDestroy()
    {
        EventBroker.LevelCompleted -= EnableParticles;
    }
}
