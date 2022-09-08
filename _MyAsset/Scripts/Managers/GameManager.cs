using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private GameStates state;

    private int collectedDiamondCount = 0;

    private void Start()
    {
        
    }

    public void IncreaseDiamond()
    {
        collectedDiamondCount += 1;
    }

    public void DecreaseDiamond()
    {
        collectedDiamondCount -= 1;
    }
    public int CollectedDiamondCount { get => collectedDiamondCount; set => collectedDiamondCount = value; }

    public void IncreaseScore(int value)
    {
        SetScore(GetScore() + value);
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt(GameVariables.Score.ToString());
    }    

    public void SetScore(int value)
    {
        PlayerPrefs.SetInt(GameVariables.Score.ToString(), value);
    }

    public GameStates GetState()
    {
        return state;
    }

    public void SetState(GameStates value)
    {
        state = value;
    }

    public int GetLevel()
    {
          return PlayerPrefs.GetInt(GameVariables.Level.ToString());
    }

    public void SetLevel(int value)
    {
        PlayerPrefs.SetInt(GameVariables.Level.ToString(), value);
    }

    public void IncreaseLevel()
    {
        SetLevel(GetLevel() + 1);
    }

}
