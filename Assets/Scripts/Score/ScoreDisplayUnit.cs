using System;
using UnityEngine.UI;
using UnityEngine;

[Serializable]
public class ScoreDisplayUnit {
    public GameObject gameObject;
    public Image icon;
    public Text numberKilled;
    public Text scorePerKill;
    public Text totalScore;

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }

    public void SetValues(ScoreIdentifier identifier, int kills) {
        icon.sprite = identifier.Icon;
        numberKilled.text = kills.ToString();
        scorePerKill.text = identifier.ScorePerKill.ToString();
        totalScore.text = (identifier.ScorePerKill * kills).ToString();
    }
}