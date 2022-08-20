using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private FoodConfig _config;
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerFoodHandler player = other.GetComponent<PlayerFoodHandler>();

        if (player == null)
        {
            return;
        }

        player.GetFoodFromKitchen(new Food(_config));

        _effect.Play();
    }
}
