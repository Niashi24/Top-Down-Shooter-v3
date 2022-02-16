using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletPrefabReference : ScriptableObject
{
    [SerializeField]
    private BulletManager manager;

    public event System.Action<BulletManager> OnChange;

    public BulletManager Value {get => manager; set {
        manager = value;
        OnChange?.Invoke(value);
    }}
}
