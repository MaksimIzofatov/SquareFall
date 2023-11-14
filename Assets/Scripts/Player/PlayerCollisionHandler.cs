using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerDied;
    [SerializeField] private UnityEvent _squareCollected;
    [SerializeField] private UnityEvent _diamondCollected;
    [SerializeField] private float _scaleChangeDuration;
    [SerializeField] private ScoreController _scoreController;
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag(GlobalConstans.ALLY_TAG)){
            collider.enabled = false;
            var square = collider.gameObject.GetComponent<SquareController>();
            _scoreController.SetScorePreSquare(square.GetScorePreSquare());
            _scoreController.SetScorePreDiamond(square.GetScorePreDiamond());

            collider.transform.DOScale(Vector3.zero, _scaleChangeDuration)
                            .OnComplete(() => {
                                _squareCollected?.Invoke();
                                _diamondCollected?.Invoke();
                                Destroy(collider.gameObject);
                            });
            
        }

        if(collider.CompareTag(GlobalConstans.ENEMY_TAG)){
            _playerDied?.Invoke();
        }
    }
}
