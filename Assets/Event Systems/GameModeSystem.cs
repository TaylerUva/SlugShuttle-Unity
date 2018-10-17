﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSystem : MonoBehaviour {

    public enum GameMode { CLASSIC, SURVIVAL };
    private int currentGameMode;

    public void SetGameMode(GameMode mode){
        int modeValue;
        switch (mode){
        case GameMode.CLASSIC: 
            modeValue = 0; break;
        case GameMode.SURVIVAL:
            modeValue = 1; break;
        default:
            modeValue = 0; break;
        }
        PlayerPrefs.SetInt("gameMode", modeValue);
    }

    public GameMode GetGameMode(){
        currentGameMode = PlayerPrefs.GetInt("gameMode");
        GameMode newGameMode;
        switch (currentGameMode) {
        case 0:
            newGameMode = GameMode.CLASSIC; break;
        case 1:
            newGameMode = GameMode.SURVIVAL; break;
        default:
            newGameMode = GameMode.CLASSIC; break;
        }
        return newGameMode;
    }
}
