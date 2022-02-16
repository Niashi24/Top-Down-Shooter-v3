using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tags
{
    public const string Bullet = "Bullet";
    public const string Enemy = "Enemy";
    public const string Player = "Player";

    public static bool IsEnemyTo(this MonoBehaviour mono, string otherTag) {
        if (otherTag == Enemy) return mono.tag == Player;
        if (otherTag == Player) return mono.tag == Enemy;
        return false;
    }

    public static bool IsEnemyTo(this MonoBehaviour mono, GameObject other) =>
        IsEnemyTo(mono, other.tag);
}
