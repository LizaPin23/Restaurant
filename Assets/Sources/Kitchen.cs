using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private FoodConfig _config;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SpriteRenderer _foodIcon;

    private void Start()
    {
        _foodIcon.sprite = _config.Icon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerFoodHandler player = other.GetComponent<PlayerFoodHandler>();

        if (player == null)
        {
            return;
        }

        bool success = player.TryGetFoodFromKitchen(new Food(_config));

        if(_effect != null && success)
            _effect.Play();
        if (_audio != null && success)
            _audio.Play();
    }
}
