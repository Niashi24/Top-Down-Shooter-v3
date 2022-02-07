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
    IntReference _scoreReference;
    [SerializeField]
    IntReference _scoreForKill;

    void OnEnable() => _playerController.OnDeath.AddListener(GiveScore);

    private void GiveScore(PlayerController controller)
    {
        _scoreReference.Value += _scoreForKill.Value;
    }
}
