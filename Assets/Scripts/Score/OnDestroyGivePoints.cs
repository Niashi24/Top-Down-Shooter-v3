using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using System;
using Sirenix.OdinInspector;

public class OnDestroyGivePoints : MonoBehaviour
{
    [SerializeField, Required]
    PlayerController _playerController;
    [SerializeField]
    ScoreTracker _scoreTracker;
    [SerializeField]
    ScoreIdentifier _identifier;

    void OnEnable() => _playerController.OnDeath.AddListener(GiveScore);

    private void GiveScore(PlayerController controller)
    {
        _scoreTracker.AddKill(_identifier);
    }
}
