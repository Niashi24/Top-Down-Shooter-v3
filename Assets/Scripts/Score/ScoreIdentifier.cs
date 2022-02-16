using UnityEngine;

[CreateAssetMenu]
public class ScoreIdentifier : ScriptableObject {
    [SerializeField]
    int _scorePerKill = 100;
    public int ScorePerKill => _scorePerKill; 

    [SerializeField]
    Sprite _icon;
    public Sprite Icon => _icon;
}