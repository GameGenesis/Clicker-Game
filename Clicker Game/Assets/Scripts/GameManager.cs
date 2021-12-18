using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }
    public int ClickValue { get; private set; }

    public event Action<int> onScoreChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        onScoreChanged?.Invoke(Score);
    }

    public void IncreaseClickValue(int value)
    {
        ClickValue += value;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("ClickValue", ClickValue);
    }

    private void Load()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        ClickValue = PlayerPrefs.GetInt("ClickValue", 1);
        onScoreChanged?.Invoke(Score);
    }
}
