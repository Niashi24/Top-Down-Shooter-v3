using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public static GameManager I {get; private set;}

    public static event Action<GameState> OnStateChange;

    [SerializeField] GameObject _upgradePanel;
    [SerializeField] PathManager _pathManager;
    [SerializeField] GameObject _scorePanel;

    [Header("State")]

    [SerializeField] GameState _initialState;

    [ReadOnly, ShowInInspector]
    public GameState State {get; private set;}

    void Awake() {
        if (I == null){
            I = this;
            //DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }

        State = _initialState;
    }

    public void ChangeState(GameState newState) {
        if (newState == State) return;
        State = newState;
        
        OnStateChange?.Invoke(State);
        switch (State) {
            case GameState.StartGame:
                _upgradePanel.SetActive(false);
                _pathManager.StartMove();
                ChangeState(GameState.Game);
                break;
            case GameState.End:
                _scorePanel.SetActive(true);
                break;
        }
    }
}
