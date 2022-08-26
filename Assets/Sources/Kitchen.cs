using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private FoodConfig _config;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Image _foodIcon;

    private void Start(Sprite icon)
    {
        _foodIcon.sprite = icon;
    }

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
