using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private FoodConfick _config;
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerFoodHandler player = other.GetComponent<PlayerFoodHandler>();

        if (player == null)
        {
            return;
        }

        player.BringFood(_config);

        _effect.Play();
    }
}
