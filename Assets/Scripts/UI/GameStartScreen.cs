using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartScreen : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private TextMeshProUGUI _text;
    private void OnEnable()
    {
        _text.text = _scoreController.GetDiamondScore().ToString();
    }

  public void UpdateText()
  {
    _text.text = _scoreController.GetDiamondScore().ToString();
  }

}
