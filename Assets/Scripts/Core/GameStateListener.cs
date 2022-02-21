using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class GameStateListener : MonoBehaviour
{
    [SerializeField] GameState _gameState;
    [SerializeField] UnityEvent OnChangesToState;

    void OnEnable() {
        GameManager.OnStateChange += Activate;
    }

    void OnDisable() {
        GameManager.OnStateChange -= Activate;
    }

    void Activate(GameState state)
    {
        if (_gameState == state) {
            OnChangesToState?.Invoke();
        }
    }
}
