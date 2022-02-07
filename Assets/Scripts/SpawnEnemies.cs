using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using Sirenix.OdinInspector;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] int totalEnemies = 10;
    [SerializeField] FloatReference _currentProgress;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] Transform _currentPathPosition;
    [SerializeField] WeightedRandom<GameObject> enemiesToSpawn;
    [ShowInInspector, ReadOnly]
    int enemiesSpawned = 0;

    public event System.Action<GameObject> OnSpawnEnemy;

    void Update() {
        var currentValue = GetCurrentValue();
        if (currentValue > enemiesSpawned) {
            SpawnEnemy(currentValue - enemiesSpawned);
            enemiesSpawned = currentValue;
        }
    }

    int GetCurrentValue() {
        return (int)(totalEnemies * _curve.Evaluate(_currentProgress.Value));
    }

    public void SpawnEnemy(int times) {
        for (int i = 0; i < times; i++) SpawnEnemy();
    }

    public void SpawnEnemy() {
        Vector3 offset = Vector2.up * 14.4f;

        var enemy = Instantiate(
            enemiesToSpawn.GetRandom(), 
            _currentPathPosition.position + offset, 
            Quaternion.Euler(0,0,180)
        );

        OnSpawnEnemy?.Invoke(enemy);
    }

}
