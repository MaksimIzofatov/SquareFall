using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorderCollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag(GlobalConstans.PLAYER_TAG)){
            _audio.Play();
        }
    }
}
