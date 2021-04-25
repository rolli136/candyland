using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    //TODO Show Lives, Reduce Lives, Add Danger
    
    private int _score = 0;
    
    [SerializeField] private Text _scoreText;

    private int _lives = 3;

    [SerializeField] private Text _livesText;
    
    [SerializeField] private Text _gameOverText;


    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + _score;
        _livesText.text = "Lives: " + _lives;
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score;
    }
    
    public void ReduceLives(int _lives)
    {
        Color _healthColor = Color32.Lerp(Color.red, Color.green, Mathf.Clamp01(_lives));
        _livesText.color = _healthColor;
        _livesText.text = "Lives: " + _lives;
    }
    
    public void ShowGameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}

