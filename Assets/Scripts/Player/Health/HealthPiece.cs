using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPiece : MonoBehaviour
{
    [SerializeField] GameObject _healthPic;
    [SerializeField] GameObject _healthBG;

    public bool healthEnabled {get; private set;}

    public void SetEnabled(bool enabled) {
        healthEnabled = enabled;
        _healthPic.SetActive(enabled);
    }
}
