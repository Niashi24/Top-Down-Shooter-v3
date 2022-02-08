using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameState : MonoBehaviour
{
    [SerializeField] GameState newState;
    public void SetState() {
        if (GameManager.I == null)
        {
            Debug.LogWarning(
                "Trying to Change State When GameManager not Initialized",
                this
            );
            return;
        }
        GameManager.I.ChangeState(newState);
    }
}
