using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Upgrade
{
  public class UpgradePercentDiamond : MonoBehaviour
  {
    public const string PERCENT_DIAMOND = "percentDiamond";

    [SerializeField] private int _percent;
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private int _cost;

    private void OnEnable()
    {
      _percent = PlayerPrefs.GetInt(PERCENT_DIAMOND);
    }

    public void UpdatePercent()
    {
      if (_scoreController.GetDiamondScore() > _cost)
      {

        if (_percent > -10)
        {
          _percent--;
          _scoreController.RemoveDiamond(_cost);
        }
        PlayerPrefs.SetInt(PERCENT_DIAMOND, _percent);
        PlayerPrefs.Save();
      }
    }
  }
}
