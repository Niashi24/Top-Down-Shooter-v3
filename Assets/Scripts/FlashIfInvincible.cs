using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashIfInvincible : MonoBehaviour
{
    [SerializeField] PlayerController _controller;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] float _flashTime = 0.1f;
    float timer;

    bool toggle = false;

    void OnEnable() {
        _controller.OnGetHit.AddListener(StartFlash);    
    }

    void OnDisable() {
        _controller.OnGetHit.RemoveListener(StartFlash);    
    }

    private void StartFlash(PlayerController playerController)
    {
        timer = _flashTime;
    }

    void Update() {
        if (_controller.IsInvincible) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                _sprite.enabled = (toggle = !toggle);
                timer = _flashTime;
            }
        } else _sprite.enabled = true;
    }
}
