using Assets.Scripts.Upgrade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField] private SquareController[] _squarePrefabs;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private Transform _leftSpawnBorder;
    [SerializeField] private Transform _rightSpawnBorder;
    [SerializeField] private Transform _leftTargetBorder;
    [SerializeField] private Transform _rightTargetBorder;
  
    private float _delayBeforeNextSpawn;
  private int _percentBlueSquare;
  private int _percentDiamond;

  private void OnEnable()
  {
    _percentBlueSquare = PlayerPrefs.GetInt(UpgradePercentBlueSquare.PERCENT_BLUE_SQUARE);
    _percentDiamond = PlayerPrefs.GetInt(UpgradePercentDiamond.PERCENT_DIAMOND);
  }
  private void Update()
    {
        if(_delayBeforeNextSpawn > 0){
            _delayBeforeNextSpawn -= Time.deltaTime;
            return;
        }
      
        var square = SpawnRandomSquare();
        var targetDirection = GetTargetDirection(square);
        square.SetDirection(targetDirection);

        _delayBeforeNextSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private Vector3 GetTargetDirection(SquareController square){
        var targetPosition = GenerateRandomPointOnLine(_leftTargetBorder, _rightTargetBorder);
        var direction = targetPosition - square.transform.position;
        return direction;
    }

    private Vector3 GenerateRandomPointOnLine(Transform left, Transform right){
        var randomProgress = Random.Range(0f, 1f);
        return Vector3.Lerp(left.position, right.position, randomProgress);
    }

    private SquareController SpawnRandomSquare(){
        int randomPrefabNumber = Random.Range(0, 2);
        if(Random.Range(-10, _percentBlueSquare) == -7 && randomPrefabNumber == 0){
            randomPrefabNumber = 2;
        }

        if(Random.Range(-25, _percentDiamond) == -15){
            randomPrefabNumber = 3;
        }

        var square = Instantiate(_squarePrefabs[randomPrefabNumber], transform);
        square.transform.position = GenerateRandomPointOnLine(_leftSpawnBorder, _rightSpawnBorder);
        return square;
    } 
}
