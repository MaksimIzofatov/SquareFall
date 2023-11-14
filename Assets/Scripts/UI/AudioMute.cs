using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
  private const string MUTE = "mute";
  [SerializeField] private Image _onImage;
  [SerializeField] private Image _offImage;
  private AudioSource[] _audioSources;
  private bool _isMute;
  private int _isMuteInt;

  private void OnEnable()
  {
    _isMuteInt = PlayerPrefs.GetInt(MUTE);
    _isMute = _isMuteInt == 1;
    if (_audioSources == null)
      _audioSources = FindObjectsOfType<AudioSource>(true);
    MuteAudio();
    OnOff();

  }


  public void OnMuteClick()
  {
    _isMute = !_isMute;

    MuteAudio();
    OnOff();

    
    
    

    _isMuteInt = _isMute ? 1 : 0;
    PlayerPrefs.SetInt(MUTE, _isMuteInt);
    PlayerPrefs.Save();
  }

  private void OnOff()
  {
    _onImage.enabled = !_isMute;
    _offImage.enabled = _isMute;
  }

  private void MuteAudio()
  {
    foreach (var audio in _audioSources)
    {
      audio.mute = _isMute;
    }
  }
}
