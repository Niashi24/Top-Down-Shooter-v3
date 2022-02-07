using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Sirenix.OdinInspector;

public class HealthManager : MonoBehaviour
{
    [SerializeField] IntReference _currentHealth;
    [SerializeField] IntReference _maxHealth;

    [SerializeField] HealthPiece[] healthPieces;
    
    void Start() => UpdateUI();

    [Button]
    public void UpdateUI() {
        for (int i = 0; i < healthPieces.Length; i++) {
            healthPieces[i].gameObject.SetActive(i < _maxHealth);
            healthPieces[i].SetEnabled(i < _currentHealth);
        }
    }
}
