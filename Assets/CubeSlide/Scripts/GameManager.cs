using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState gameState;
    
    public static Action<GameState> onGameStateChange;
    
    public enum GameState
    {
        GameOver,
        Menu,
        Game,
        LevelComplete
    }

    private void Awake()
    {
        if (instance != null) {

            Destroy(gameObject);

        }
        else
            instance = this;
        
    }

    private void Start()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        
        onGameStateChange?.Invoke(gameState);
        Debug.Log("Game State Change " + gameState);
        
    }


    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
