using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")] [SerializeField] private GameObject _coinPrefabs;
    [SerializeField] private GameObject _powerUpSweetsPrefabs;


    [Header("Parents")] [SerializeField] private GameObject _coinParent;
    [SerializeField] private GameObject _powerUpParent;
    private bool _spawningOn = true;

    private float _coinPositionX = 1f;
    private float _spaceBetweenCoins = 2.5f;
    private float nextPositionCoinX = 1f;
    private int _counter = 0;

    private int _numberCoins = 100;

    private void Start()
    {
        StartCoroutine(CoinSpawnSystem());
    }
    

    IEnumerator CoinSpawnSystem()
    {
      
            while (_numberCoins > 0)
            {
                //Instantiate Coins
                Instantiate(_coinPrefabs,
                    new Vector3(Random.Range(-33f, 140f), 2.5f, Random.Range(-35f, 50f)),
                    Quaternion.Euler(90f, 0f, 0f),
                    _coinParent.transform);


                //Instantiate PowerUps
                // Every 10th there should also be an Instantiation of PowerUps
                if ((_numberCoins % 10) == 0)
                {
                    Instantiate(_powerUpSweetsPrefabs,
                        new Vector3(Random.Range(-33f, 140f), 3f, Random.Range(-35f, 50f)),
                        Quaternion.Euler(90f, 0f, 0f), _powerUpParent.transform);
                }
                _numberCoins--;
            }
            yield return null;
    }
}