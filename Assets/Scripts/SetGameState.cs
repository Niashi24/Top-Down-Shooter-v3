using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameState : MonoBehaviour
{
    [SerializeField] GameState newState;
    public void SetState() {
        GameManager.I?.ChangeState(newState);
    }
}
