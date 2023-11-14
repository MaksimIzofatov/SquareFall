using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePercentBlueSquare : MonoBehaviour
{
  public const string PERCENT_BLUE_SQUARE = "percentBlueSquare";

  [SerializeField] private int _percent;
  [SerializeField] private ScoreController _scoreController;
  [SerializeField] private int _cost;

  private void OnEnable()
  {
    _percent = PlayerPrefs.GetInt(PERCENT_BLUE_SQUARE);
  }

  public void UpdatePercent()
  {
    if(_scoreController.GetDiamondScore() > _cost)
    {

      if (_percent > -5)
      {
        _percent--;
        _scoreController.RemoveDiamond(_cost);
      }
      PlayerPrefs.SetInt(PERCENT_BLUE_SQUARE, _percent);
      PlayerPrefs.Save();
    }
  }

}
