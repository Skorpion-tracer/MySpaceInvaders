using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI
{
    private Text _scoreText;
    private int _score;

    public int Score { get => _score; set => _score = value; }

    public MainUI(Text scoreText, int score)
    {
        _scoreText = scoreText;
        _score = score;
    }

    public void Execute()
    {
        _scoreText.text = $"Score: {Score}";
    }
}
