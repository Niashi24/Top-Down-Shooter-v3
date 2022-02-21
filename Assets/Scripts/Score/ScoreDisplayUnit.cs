using System;
using UnityEngine.UI;

[Serializable]
public class ScoreDisplayUnit {
    public Image icon;
    public Text numberKilled;
    public Text scorePerKill;
    public Text totalScore;

    public void SetActive(bool active) {
        icon.enabled = active;
        numberKilled.enabled = active;
        scorePerKill.enabled = active;
        totalScore.enabled = active;
    }

    public void SetValues(ScoreIdentifier identifier, int kills) {
        icon.sprite = identifier.Icon;
        numberKilled.text = kills.ToString();
        scorePerKill.text = identifier.ScorePerKill.ToString();
        totalScore.text = (identifier.ScorePerKill * kills).ToString();
    }
}