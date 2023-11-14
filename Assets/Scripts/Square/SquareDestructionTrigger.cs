using UnityEngine;
using DG.Tweening;


public class SquareDestructionTrigger : MonoBehaviour
{
    [SerializeField] private float _scaleChangeDuration;
    private void OnTriggerEnter2D(Collider2D collider){
       if(collider.tag != GlobalConstans.PLAYER_TAG){
        collider.enabled = false;

        collider.transform.DOScale(Vector3.zero, _scaleChangeDuration)
        .OnComplete(() => Destroy(collider.gameObject));
       }
        
        
    }

}
