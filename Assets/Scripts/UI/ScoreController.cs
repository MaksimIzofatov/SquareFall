using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class ScoreController : MonoBehaviour
{
    private const string BEST_SCORE = "bestScore";
    private const string DIAMOND_SCORE = "diamondScore";
    private int _currentScore;
    private int _bestScore;
    private int _diamondScore;
    private int _currentDiamondScore;
    [SerializeField] private TextMeshProUGUI _currentScoreLabel;
    private int _scorePreSquare;
    [SerializeField] private AudioSource _bestScoreSound;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _scaleFactor;
    
    private void Awake(){
        _bestScore = PlayerPrefs.GetInt(BEST_SCORE);
        _diamondScore = PlayerPrefs.GetInt(DIAMOND_SCORE);
    }


    public void AddScore(){
        _currentScore += _scorePreSquare;

        _currentScoreLabel.text = _currentScore.ToString();
        _currentScoreLabel.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 0).OnComplete(() => _currentScoreLabel.transform.DOScale(Vector3.one, 0));
    }

    public int GetCurrentScore() => _currentScore;
    public void SetScorePreSquare(int score) => _scorePreSquare = score;

    public int GetBestScore(){
        if(_currentScore > _bestScore){
            _bestScore = _currentScore;
            PlayerPrefs.SetInt(BEST_SCORE, _bestScore);
            PlayerPrefs.Save();
            _bestScoreSound.Play();
            
        }

        return _bestScore;
    }

    public void AddDiamond()
  {
    _diamondScore += _currentDiamondScore;

    SaveDiamond();
  }

  private void SaveDiamond()
  {
    PlayerPrefs.SetInt(DIAMOND_SCORE, _diamondScore);
    PlayerPrefs.Save();
  }

  public void RemoveDiamond(int diamond)
  {
    if (diamond > _diamondScore)
      return;

    _diamondScore -= diamond;
    SaveDiamond();

  }

    public void SetScorePreDiamond(int score)
    {
        _currentDiamondScore = score;
    }
    public int GetDiamondScore() => PlayerPrefs.GetInt(DIAMOND_SCORE);
}
